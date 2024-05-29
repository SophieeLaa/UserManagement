using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Security;

namespace UserManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtService _jwtService;

        public AuthService(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public async Task<string> GenerateJwtTokenAsync(User user)
        {
            return _jwtService.GenerateToken(user);
        }
    }
}