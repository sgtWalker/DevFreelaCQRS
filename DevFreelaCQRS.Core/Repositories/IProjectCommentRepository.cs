using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.Core.Repositories
{
    public interface IProjectCommentRepository : IBaseRepository<ProjectComment>
    {
        Task<ProjectComment> GetDetailsByIdAsync(Guid id);
        Task<List<ProjectComment>> GetProjectCommentsByProjectIdAsync(Guid projectId);
        Task<List<ProjectComment>> GetProjectCommentsByProjectIdAndUserIdAsync(Guid projectId, Guid userId);
        Task<List<ProjectComment>> GetProjectCommentsByUserIdAsync(Guid userId);
    }
}
