using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.Core.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<Project> GetDetailsByIdAsync(Guid id);
    }
}
