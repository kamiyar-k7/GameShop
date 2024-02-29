using Data.ShopDbcontext;
using Domain.entities.GamePart.Game;
using Domain.IRepository.CatalogRepositoryInterface;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.CatalogRepository
{
    public class CatalogRepository : ICatalogRepository
    {
        #region Ctor
        private readonly GameShopDbContext _gameShopDbContext;
        public CatalogRepository(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext; 
        }

        #endregion

        #region General
        public async Task<List<Game>> GetListOfGames()
        {
            return await _gameShopDbContext.games.Where(x=> x.IsDelete == false).
                Include(x=>x.Screenshots ).
                Include(x=> x.gameSelectedPlatforms).
                Include(x => x.gemeSelectedGenres).
                ToListAsync();
        }
        #endregion
    }
}
