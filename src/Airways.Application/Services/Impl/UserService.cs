using Airways.Application.DataTransferObject.Authentication;
using Airways.Application.DTO;
using Airways.Application.Models;
using Airways.Core.Entity;
using Airways.DataAccess;
using Airways.DataAccess.Authentication;
using Airways.DataAccess.Repository;
using Airways.DataAccess.Repository.Impl;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Airways.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<UserForCreationDTO> _userValidator;
        private readonly IValidator<LoginDTO> _loginValidator;
        private readonly IValidator<UpdateUserDTO> _updateUserValidator;

        public UserService(IUserRepository usersRepo, 
            IPasswordHasher passwordHasher, 
            IValidator<UserForCreationDTO> userValidator,
            IValidator<LoginDTO> loginValidator,
            IValidator<UpdateUserDTO> updateUserValidator)
        {
            _usersRepo = usersRepo;
            _passwordHasher = passwordHasher;
            _userValidator = userValidator;
            _loginValidator = loginValidator;
            _updateUserValidator = updateUserValidator;
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _usersRepo.GetFirstAsync(u => u.Id == id);
            

            if (user == null)
                return null;

            return new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Id = user.Id
            };
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _usersRepo.GetAllAsync(u => true);
            return users.Select(user => new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Id = user.Id
            }).ToList();
        }

        public async Task<User> AddUserAsync(UserForCreationDTO userForCreationDTO)
        {
            var validationResult = await _userValidator.ValidateAsync(userForCreationDTO);
            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (userForCreationDTO == null)
                throw new ArgumentNullException(nameof(userForCreationDTO));

            string randomSalt = Guid.NewGuid().ToString();

            User user = new User
            {
                Name = userForCreationDTO.Name,
                Email = userForCreationDTO.Email,
                Address = userForCreationDTO.Address,

                Salt = randomSalt,
                Password = _passwordHasher.Encrypt(
                    password: userForCreationDTO.Password,
                    salt: randomSalt),
                Role = userForCreationDTO.Role

            };
            var res = await _usersRepo.AddAsync(user);
            var result = new UserDTO
            {
                Address = userForCreationDTO.Address,
                Email = userForCreationDTO.Email,
                Name = userForCreationDTO.Name
            };
            
            return MapToDTO(res);
        }

        public async Task<User> UpdateUserAsync(Guid id, UpdateUserDTO userDto)
        {
            var validationResult = await _updateUserValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto), "UserDTO cannot be null.");

            var user = await _usersRepo.GetFirstAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));  
            }
            
            string randomSalt = Guid.NewGuid().ToString();

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Address = userDto.Address;
            user.Salt = randomSalt;
            user.Password = _passwordHasher.Encrypt(
                password: userDto.Password,
                salt: randomSalt);
          
            await _usersRepo.UpdateAsync(user);

            return user; 
        }

        public async Task<AuthorizationUserDTO> AuthenticateAsync(LoginDTO loginDTO)
        {
            var validationResult = await _loginValidator.ValidateAsync(loginDTO);
            if (!validationResult.IsValid)
            {   
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _usersRepo.GetFirstAsync(u => u.Email == loginDTO.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            var isPasswordValid = _passwordHasher.Verify(user.Password, loginDTO.Password, user.Salt);
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            return MapToDTOLogin(user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _usersRepo.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return false;

            await _usersRepo.DeleteAsync(user);
            return true;
        }

        private AuthorizationUserDTO MapToDTOLogin(User user)
        {
            return new AuthorizationUserDTO
            {
                Password = user.Password,
                Email = user.Email,
                Role = user.Role
            };
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _usersRepo.GetUserByEmailAsync(email);
        }
        public async Task<bool> VerifyPassword(User user, string password)
        {
            return await Task.Run(() => user.Password == password);
        }

        private User MapToDTO(User user)
        {
            return new User
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address
            };
        }
    }
}
