using Airways.API;
using Airways.API.Filters;
using Airways.API.Middleware;
using Airways.Application;
using Airways.Application.BackgroundServices;
using Airways.Application.Common.Email;
using Airways.DataAccess;
using Airways.DataAccess.Authentication;
using Airways.DataAccess.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using StackExchange.Redis;
using System.Collections.Specialized;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuartz(q =>
{

    q.AddJob<RabbitJob>(opts => opts.WithIdentity("dailyRabbitMqJob", "group1"));
    q.AddTrigger(opts => opts
        .ForJob("dailyRabbitMqJob", "group1")
        .WithIdentity("dailyTrigger", "group1")
        .StartNow()
        .WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever()));

});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddSingleton<RabbitMqConsumer>(sp => new RabbitMqConsumer("api.ticket"));

// Configure services
builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);

var redisOptions = new ConfigurationOptions
{
    EndPoints = { builder.Configuration.GetConnectionString("Redis")!.Split(',')[0] },
    AbortOnConnectFail = false,
    ConnectTimeout = 5000,
    SyncTimeout = 5000,
    ConnectRetry = 3,
    KeepAlive = 60,
    DefaultDatabase = 0
};

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket API", Version = "v1" });
    c.OperationFilter<HtmlResponseOperationFilter>();
});

builder.Services.AddSwagger();

builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<SmtpSettings>>().Value);

builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
        policy.RequireRole("Role", "User"));

    options.AddPolicy("Admin", policy =>
        policy.RequireRole("Role", "Admin"));
});

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
ConnectionMultiplexer.Connect(redisOptions));

builder.Services.AddHostedService<RedisSubscriberService>();

var jwtOption = builder.Configuration.GetSection("JwtOptions").Get<JwtOption>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOption.Issuer,
        ValidAudience = jwtOption.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOption.SecretKey))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<DataBaseContext>();

await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airways"); });

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlerMiddlewear>();
app.UseMiddleware<RabbitMqMiddleware>();

app.MapControllers();

app.Run();

namespace Airways.API
{
    public partial class Program { }
}
