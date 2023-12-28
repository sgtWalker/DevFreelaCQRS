using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.Core.Repositories
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(Guid id);
        Task<Project> GetDetailsByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
