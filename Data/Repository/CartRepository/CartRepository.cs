using Data.ShopDbcontext;
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
        #endregion

        #region General 
        public async Task<List<Cart>> GetListOfUserCart(int id)
        {
            return await _dbContext.Carts.Where(x=> x.UserId == id).ToListAsync();
        }

        public async Task AddToCart(Cart cart)
        {
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteCart()
        {
            await _dbContext.Carts.Where();
        }
        #endregion
    }
}
