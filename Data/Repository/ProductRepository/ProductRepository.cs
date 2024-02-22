using Data.ShopDbcontext;
using Domain.entities.Store.Game;
using Domain.IRepository.ProductRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        #region Ctor
        private readonly GameShopDbContext _gameShopDbContext;
        public ProductRepository(GameShopDbContext gameShopDbContext)
        {
                _gameShopDbContext = gameShopDbContext;
                
        }
        #endregion

        #region General
        public async Task<Game> GetGameById(int Id)
        {
            return await _gameShopDbContext.games.FirstAsync(x => x.Id == Id);
        }
        #endregion

    }
}
