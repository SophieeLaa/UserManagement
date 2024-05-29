using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Data.Contexts;

namespace UserManagement.Infrastructure.Data.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        // Implement other IRepository methods as needed

        public async Task AddAsync(Role entity)
        {
            await _dbContext.Roles.AddAsync(entity);
        }

        public async Task UpdateAsync(Role entity)
        {
            _dbContext.Roles.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Role entity)
        {
            _dbContext.Roles.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
