using RB.TBC.FinalProject.Domain.Entitites;

namespace RB.TBC.FinalProject.Domain.Interface
{
    public interface ICrud<T> where T : class
    {
        Task<string> AddAsync(T entity);
        Task<bool> RemoveAsync(T entity);
        Task<bool> UpdateAsync(string id, T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
    }
}
