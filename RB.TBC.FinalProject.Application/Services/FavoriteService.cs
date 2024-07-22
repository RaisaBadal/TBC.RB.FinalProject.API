using AutoMapper;
using Microsoft.Extensions.Logging;
using RB.TBC.FinalProject.Application.Interface;
using RB.TBC.FinalProject.Application.Models;
using RB.TBC.FinalProject.Domain.Entitites;
using RB.TBC.FinalProject.Domain.Interface;

namespace RB.TBC.FinalProject.Application.Services
{
    public class FavoriteService : AbstractService<FavoriteService>, IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IMapper mapper, ILogger<FavoriteService> logger, IFavoriteRepository favoriteRepository)
            : base(mapper, logger)
        {
            _favoriteRepository = favoriteRepository;
        }

        #region AddAsync
        public async Task<string> AddAsync(FavoriteModel entity,string UserId)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            var mapped = mapper.Map<Favorite>(entity);
            if (mapped != null)
            {
                mapped.UserId = UserId;
                mapped.FavoriteId = Guid.NewGuid().ToString();
                return await _favoriteRepository.AddAsync(mapped);
            }
            throw new ArgumentNullException("Internal server error");
        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<FavoriteModel>> GetAllAsync()
        {
            var favorites = await _favoriteRepository.GetAllAsync();
            if (favorites.Any())
            {
                var mapped = mapper.Map<IEnumerable<FavoriteModel>>(favorites);
                return mapped;
            }
            throw new ArgumentNullException("No favorites found");
        }
        #endregion

        #region GetByIdAsync
        public async Task<FavoriteModel> GetByIdAsync(string userId, string bookId)
        {
            var favorite = await _favoriteRepository.GetByIdAsync(userId, bookId);
            if (favorite != null)
            {
                var mapped = mapper.Map<FavoriteModel>(favorite);
                return mapped;
            }
            throw new ArgumentNullException("Favorite not found");
        }
        #endregion

        #region RemoveAsync
        public async Task<bool> RemoveAsync(string userId, string bookId)
        {
            var favorite = await _favoriteRepository.GetByIdAsync(userId, bookId);
            if (favorite != null)
            {
                return await _favoriteRepository.RemoveAsync(favorite);
            }
            throw new ArgumentNullException("Favorite not found");
        }
        #endregion
    }
}
