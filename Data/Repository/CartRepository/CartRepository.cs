using Data.ShopDbcontext;
using Domain.entities.Cart;
using Domain.entities.GamePart.Game;
using Domain.entities.UserPart.User;
using Domain.IRepository.CartRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.CartRepository
{
    public class CartRepository : ICartRepository
    {
        #region Ctor
        private readonly GameShopDbContext _dbContext;

        public CartRepository(GameShopDbContext gameShop)
        {
            _dbContext = gameShop;
        }
        public async Task AddUserCartToCarts(Carts carts)
        {
            await _dbContext.Cart.AddAsync(carts);
            await _dbContext.SaveChangesAsync();

        }
        public async Task AddToCart(CartDeatails cartDeatails )
        {
          await  _dbContext.CartDeatails.AddAsync(cartDeatails);
            await _dbContext.SaveChangesAsync();
        }

        public Task AddToCart(Carts cart)
        {
            throw new NotImplementedException();
        }

        public Task<Carts> GetcartByUserId(int userid)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetGameAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Carts>> GetListOfUserCart(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region General 
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
      
        #endregion
    }
}
