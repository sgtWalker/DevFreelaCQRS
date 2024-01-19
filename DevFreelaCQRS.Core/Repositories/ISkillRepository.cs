using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.Core.Repositories
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        Task<List<Skill>> GetSkillsByDescriptionAsync(string description);
    }
}
