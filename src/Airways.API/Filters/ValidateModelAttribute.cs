﻿using Airways.Application.Models;
using Airways.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Airways.API.Filters;

public class ValidateModelAttribute : Attribute, IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                .SelectMany(modelState => modelState.Errors)
                .Select(modelError => Errorr.InternalServerError);

            context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errors.First()));
        }

        await next();
    }
}
