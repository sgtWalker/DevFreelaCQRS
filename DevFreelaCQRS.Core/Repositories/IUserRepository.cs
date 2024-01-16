using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<UserSkill>> GetUserSkillsAsync(Guid id);
    }
}
