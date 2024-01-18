using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.Core.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<Project> GetDetailsByIdAsync(Guid id);
        Task<List<Project>> GetAllByClientIdAsync(Guid clientId);
        Task<List<Project>> GetAllByDescriptionAsync(string description);
        Task<List<Project>> GetAllByFreelancerIdAsync(Guid freelancerId);
        Task<List<Project>> GetAllByTitleAsync(string description);
    }
}
