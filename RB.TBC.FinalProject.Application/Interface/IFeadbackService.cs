using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Application.Models.Response;

namespace RB.TBC.FinalProject.Application.Interface
{
    public interface IFeadbackService
    {
        Task<string> AddAsync(FeadbackModel entity, string UserId, string UserName, string Email);
        Task<bool> RemoveAsync(string  id);
        Task<bool> SoftDeleteAsync(string id);
        Task<IEnumerable<FeadbackModelResponse>> GetAllAsync();
        Task<FeadbackModelResponse> GetByIdAsync(string id);
    }
}
