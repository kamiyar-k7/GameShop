using Data.ShopDbcontext;
using Domain.entities.Store.Game;
using Domain.IRepository.CatalogRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.StoreRepository.CatalogRepository
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
            return await _gameShopDbContext.games.Where(x => x.IsDelete == false).
                Include(x => x.Screenshots).
                Include(x => x.gameSelectedPlatforms).
                Include(x => x.gemeSelectedGenres).
                ToListAsync();
        }
        #endregion
    }
}
