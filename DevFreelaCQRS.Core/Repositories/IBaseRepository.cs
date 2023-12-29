namespace DevFreelaCQRS.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
