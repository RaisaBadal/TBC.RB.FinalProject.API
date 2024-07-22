using Microsoft.EntityFrameworkCore;
using RB.TBC.FinalProject.Domain.Data;
using RB.TBC.FinalProject.Domain.Entitites;
using RB.TBC.FinalProject.Domain.Interface;

namespace RB.TBC.FinalProject.Domain.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly TbcDbContext _context;

        public FavoriteRepository(TbcDbContext context)
        {
            _context = context;
        }

        #region AddAsync
        public async Task<string> AddAsync(Favorite entity)
        {
            if (!await _context.Favorites.AnyAsync(f => f.UserId == entity.UserId && f.BookId == entity.BookId))
            {
                await _context.Favorites.AddAsync(entity);
                await _context.SaveChangesAsync();
                return $"{entity.UserId}-{entity.BookId}";
            }
            throw new ArgumentNullException("This favorite already exists in the database!");
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<Favorite>> GetAllAsync()
        {
            return await _context.Favorites.ToListAsync();
        }
        #endregion

        #region GetByIdAsync
        public async Task<Favorite> GetByIdAsync(string userId, string bookId)
        {
            var favorite = await _context.Favorites.FindAsync(userId, bookId);
            if (favorite != null)
            {
                return favorite;
            }
            throw new ArgumentNullException("No favorite found with the given user ID and book ID");
        }
        #endregion

        #region RemoveAsync
        public async Task<bool> RemoveAsync(Favorite entity)
        {
            _context.Favorites.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
