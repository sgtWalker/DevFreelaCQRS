using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<UserSkill>> GetUserSkillsAsync(Guid id) => await _context.UserSkills.Where(us => us.UserId == id).ToListAsync();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
