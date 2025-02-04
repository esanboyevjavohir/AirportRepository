using Airways.Application.Models;
using Airways.Core.Common;
using Airways.DataAccess.Repository;
using MediaBrowser.Model.Services;
using MediatR;

namespace Airways.Application.MediatorCRUD
{
    public record DeleteUserCommand(Guid Id) : IRequest<ApiResult>;
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ApiResult>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // Id bo'yicha userni olish
            var user = await _userRepository.GetByIdAsync(request.Id);
            if(user == null) 
                return ApiResult.Failure(Errorr.NotFound, "User not found");

            // Userni o'chirish
            var result = await _userRepository.DeleteAsync(user);
            if (result == null)
                return ApiResult.Failure(Errorr.DatabaseError, "Failed to delete user");

            // Muvaffaqqiyatli o'chirish
            return ApiResult.Success("User successfully deleted");
        }
    }
}
