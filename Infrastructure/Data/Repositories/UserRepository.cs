using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Data.Contexts;

namespace UserManagement.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task AddAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
