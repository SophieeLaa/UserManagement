using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Interfaces
{
    public interface IUserService
    {      
        Task<UserDTO> RegisterUserAsync(RegisterDTO registerDto);
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<UserDTO> UpdateUserAsync(int userId, UpdateUserDTO updateUserDto);
        Task<UserDTO> LoginAsync(LoginDTO loginDto);
        Task<UserDTO> GetUserProfileAsync(string userId);
        Task<UserDTO> UpdateUserProfileAsync(string userId, UpdateUserDTO updateUserDto);

    }
}
