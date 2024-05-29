using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
