using Airways.Application.DataTransferObject.Authentication;
using Airways.Application.DTO;
using Airways.Core.Entity;
using Airways.DataAccess;

namespace Airways.Application.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetByIdAsync(Guid id);
        Task<List<UserDTO>> GetAllAsync();
        Task<UserForCreationDTO> AddUserAsync(UserForCreationDTO userForCreationDto);
        Task<User> UpdateUserAsync(Guid id, UpdateUserDTO userDto);
        Task<AuthorizationUserDTO> AuthenticateAsync(LoginDTO loginDto);
        Task<bool> DeleteUserAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> VerifyPassword(User user, string password);
    }
}