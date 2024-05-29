using Domain.Entities;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Security;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork; 

        public UserService(IUserRepository userRepository, JwtService jwtService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _unitOfWork = unitOfWork; 
        }

        public async Task<UserDTO> RegisterUserAsync(RegisterDTO registerDto)
        {
            
            string passwordHash = PasswordHasher.HashPassword(registerDto.Password);

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = passwordHash
            };

            await _userRepository.AddAsync(user);

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return null;

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<UserDTO> UpdateUserAsync(int userId, UpdateUserDTO updateUserDto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return null;
            user.Username = updateUserDto.Username;
            user.Email = updateUserDto.Email;

            await _userRepository.UpdateAsync(user);

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<UserDTO> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null)
                return null;

            bool isValidPassword = PasswordHasher.ValidatePassword(loginDto.Password, user.PasswordHash);
            if (!isValidPassword)
                return null;

            string jwtToken = _jwtService.GenerateToken(user);

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                JwtToken = jwtToken
            };
        }
        public async Task<UserDTO> GetUserProfileAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            if (user == null)
            {
                return null;
            }

            var userDto = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

            return userDto;
        }

        public async Task<UserDTO> UpdateUserProfileAsync(string userId, UpdateUserDTO updateUserDto)
        {
            var user = await _userRepository.GetByIdAsync(int.Parse(userId));
            if (user == null)
            {
                return null;
            }

            user.Username = updateUserDto.Username;
            user.Email = updateUserDto.Email;

            await _userRepository.UpdateAsync(user);

            var updatedUserDto = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

            return updatedUserDto;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync(); // Call SaveChangesAsync on Unit of Work
        }
    }
}
