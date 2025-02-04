using Airways.Application.DTO;
using Airways.Application.Models;
using Airways.Application.Services;
using Airways.Core.Common;
using Airways.Core.Entity;
using MediatR;

namespace Airways.Application.MediatorCRUD
{
    public record GetAllUserQuery() : IRequest<ApiResult<List<UserDTO>>>;
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ApiResult<List<UserDTO>>>
    {
        private readonly IUserService _userService;

        public GetAllUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResult<List<UserDTO>>> Handle(GetAllUserQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync();

            if (users == null || !users.Any())
                return ApiResult<List<UserDTO>>.Failure(Errorr.NotFound, "User not found");

            return ApiResult<List<UserDTO>>.Success(users);
        }
    }
}
