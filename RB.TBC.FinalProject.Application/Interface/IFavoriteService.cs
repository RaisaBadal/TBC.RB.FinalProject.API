using RB.TBC.FinalProject.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.TBC.FinalProject.Application.Interface
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteModel>> GetAllAsync();
        Task<FavoriteModel> GetByIdAsync(string userId, string bookId);
        Task<string> AddAsync(FavoriteModel entity,string UserId);
        Task<bool> RemoveAsync(string userId, string bookId);
    }
}
