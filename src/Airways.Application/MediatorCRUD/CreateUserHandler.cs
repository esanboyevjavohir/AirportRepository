using Airways.Application.Models;
using Airways.Core.Common;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using MediaBrowser.Model.Services;
using MediatR;

namespace Airways.Application.MediatorCRUD
{
    public record CreateUserCommand(
        string Name, string Email, string Address, string Password, Role Role) 
        : IRequest<ApiResult<User>>{ }
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResult<User>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResult<User>> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            // Email va Password null bo'lsa Failure qaytaramiz
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return ApiResult<User>.Failure(Errorr.NotFound, "Email and Password cannot be empty");

            // yangi user yaratish
            var users = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Address = request.Address,
                Role = request.Role
            };

            // userni saqlash
            var user = await _userRepository.AddAsync(users);

            // Agar user null bo'lsa Failure qaytaramiz
            if (user == null)
                return ApiResult<User>.Failure(Errorr.DatabaseError, "Failed to created user!");

            return ApiResult<User>.Success(user, "User succesfully created.");
        }
    }
}
