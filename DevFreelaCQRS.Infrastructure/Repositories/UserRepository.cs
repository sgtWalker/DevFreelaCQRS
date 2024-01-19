using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreelaCQRS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly DevFreelaCQRSDbContext _context;

        public UserRepository(DevFreelaCQRSDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();

        public async Task<User> GetByIdAsync(Guid id) => await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

        public async Task<User> GetUserByEmailAsync(string email) => await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

        public async Task<List<User>> GetUsersByBirthDate(DateTime birthDate) => await _context.Users.Where(u => u.BirthDate == birthDate).ToListAsync();

        public async Task<List<User>> GetUsersByFullNameAsync(string fullName) => await _context.Users.Where(u => u.FullName.Contains(fullName)).ToListAsync();

        public async Task<User> GetUserSkillsAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Skills)
                .SingleOrDefaultAsync(u => u.Id == userId);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
