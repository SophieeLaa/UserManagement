using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDTO> GetRoleByNameAsync(string roleName);
    }
}
