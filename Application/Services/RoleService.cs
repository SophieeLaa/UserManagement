using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository; 

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDTO> GetRoleByNameAsync(string roleName)
        {
           
            var allRoles = await _roleRepository.GetAllAsync();

            var role = allRoles.FirstOrDefault(r => r.Name == roleName);

            if (role == null)
            {
                
                return null;
            }

            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name
              
            };
        }
    }
}