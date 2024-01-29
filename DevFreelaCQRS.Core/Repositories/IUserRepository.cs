using DevFreelaCQRS.Core.Entities;

namespace DevFreelaCQRS.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserSkillsAsync(Guid userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetUsersByBirthDate(DateTime birthDate);
        Task<List<User>> GetUsersByFullNameAsync(string fullName);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
