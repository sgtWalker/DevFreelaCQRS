using DevFreelaCQRS.Core.Entities;
using DevFreelaCQRS.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreelaCQRS.Infrastructure.Repositories
{
    public class ProjectCommentRepository : IProjectCommentRepository
    {
        private readonly DevFreelaCQRSDbContext _context;

        public ProjectCommentRepository(DevFreelaCQRSDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProjectComment entity)
        {
            await _context.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<List<ProjectComment>> GetAllAsync() => await _context.ProjectComments.ToListAsync();

        public async Task<ProjectComment> GetByIdAsync(Guid id) => await _context.ProjectComments.SingleOrDefaultAsync(p => p.Id == id);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
