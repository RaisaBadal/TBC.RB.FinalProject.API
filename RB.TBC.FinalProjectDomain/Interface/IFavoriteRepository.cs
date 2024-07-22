using RB.TBC.FinalProject.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.TBC.FinalProject.Domain.Interface
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetAllAsync();
        Task<Favorite> GetByIdAsync(string userId, string bookId);
        Task<string> AddAsync(Favorite entity);
        Task<bool> RemoveAsync(Favorite entity);
    }
}
