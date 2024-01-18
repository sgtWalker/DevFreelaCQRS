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
            await SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync() => await _context.Projects.ToListAsync();

        public async Task<Project> GetByIdAsync(Guid id) => await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);

        public async Task<Project> GetDetailsByIdAsync(Guid id)
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Project>> GetAllByClientIdAsync(Guid clientId) => await _context.Projects.Where(p => p.ClientId == clientId).ToListAsync();

        public async Task<List<Project>> GetAllByDescriptionAsync(string description) => await _context.Projects.Where(p => p.Description.Contains(description)).ToListAsync();

        public async Task<List<Project>> GetAllByFreelancerIdAsync(Guid freelancerId) => await _context.Projects.Where(p => p.FreelancerId == freelancerId).ToListAsync();

        public async Task<List<Project>> GetAllByTitleAsync(string title) => await _context.Projects.Where(p => p.Title.Contains(title)).ToListAsync();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
