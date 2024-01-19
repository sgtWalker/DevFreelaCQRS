using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreelaCQRS.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        protected readonly DevFreelaCQRSDbContext _context;

        public SkillRepository(DevFreelaCQRSDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Skill entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<List<Skill>> GetAllAsync() => await _context.Skills.ToListAsync();
        
        public async Task<Skill> GetByIdAsync(Guid id) => await _context.Skills.SingleOrDefaultAsync(s => s.Id == id);

        public async Task<List<Skill>> GetSkillsByDescriptionAsync(string description) => await _context.Skills.Where(s => s.Description.Contains(description)).ToListAsync();
        
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
