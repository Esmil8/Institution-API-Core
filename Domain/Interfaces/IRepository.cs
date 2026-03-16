
namespace Institution.Domain.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T?> GetById(int Id);
        Task AddAsync(T Entities);
        Task PostAsync(T Entities);
        Task UpdateAsync(T Entities);
        Task DeleteAsync(T Entities);
    } 
}