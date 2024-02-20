using Data.ShopDbcontext;
using Domain.entities.Store.Game;
using Domain.IRepository.StoreRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.StoreRepository
{
    public class StoreRepository : IStoreRepositpory
    {
        #region Ctor
        private readonly GameShopDbContext _gameShopDbContext;
        public StoreRepository(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
                
        }
        #endregion

        #region general 
        public async Task<List<Game>> GetListOfGames()
        {
            return await _gameShopDbContext.games.Where(x => x.IsDelete == false).Include(x=> x.Screenshots).ToListAsync();
             
        }
        #endregion
    }
}
