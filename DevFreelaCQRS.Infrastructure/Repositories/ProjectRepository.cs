using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreelaCQRS.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaCQRSDbContext _context;

        public ProjectRepository(DevFreelaCQRSDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> GetDetailsByIdAsync(Guid id)
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
