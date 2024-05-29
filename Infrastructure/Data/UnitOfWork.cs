using System;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Infrastructure.Data.Contexts;

namespace UserManagement.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while saving changes.", ex);
            }
        }
    }
}
