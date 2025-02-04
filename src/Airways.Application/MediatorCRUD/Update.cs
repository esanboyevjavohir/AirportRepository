using Airways.Application.Models;
using Airways.Core.Common;
using Airways.Core.Entity;
using Airways.DataAccess.Repository;
using MediatR;

namespace Airways.Application.MediatorCRUD
{
    public record UpdateUserCommand(
        Guid Id, string Name, string Email, string Address, string Password, Role Role)
        : IRequest<ApiResult>;
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ApiResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return ApiResult.Failure(Errorr.NotFound, "User not found");

            user.Name = request.Name;
            user.Email = request.Email;
            user.Address = request.Address;
            user.Password = request.Password;
            user.Role = request.Role;

            var result = await _userRepository.UpdateAsync(user);
            if (result == null)
                return ApiResult.Failure(Errorr.DataBaseError, "Failed to update user");

            return ApiResult.Success("User successfully update");
        }
    }
}
