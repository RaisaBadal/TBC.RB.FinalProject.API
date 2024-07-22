using RB.TBC.FinalProject.Domain.Entitites;

namespace RB.TBC.FinalProject.Domain.Interface
{
    public interface IFeadbackRepository
    {
        Task<string> AddAsync(Feadback entity);
        Task<bool> RemoveAsync(Feadback entity);
        Task<bool> UpdateAsync(string id, Feadback entity);
        Task<bool> SoftDeleteAsync(string id);
        Task<IEnumerable<Feadback>> GetAllAsync();
        Task<Feadback> GetByIdAsync(string id);
    }
}
