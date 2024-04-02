using Data.ShopDbcontext;
using Domain.entities.Cart;
using Domain.entities.GamePart.Game;
using Domain.entities.UserPart.User;
using Domain.IRepository.UserPart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.UserPart
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

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddUserCartToCarts(Carts carts)
        {
            await _dbContext.Cart.AddAsync(carts);
            await SaveChanges();

        }

        public async Task AddToCart(CartDeatails cartDeatails)
        {
            await _dbContext.CartDeatails.AddAsync(cartDeatails);
            await SaveChanges();
        }
        public async Task AddOneMoreToCart(CartDeatails cartDeatails)
        {
            _dbContext.CartDeatails.Update(cartDeatails);
            await SaveChanges();
        }
        public CartDeatails? IsGameExistInCart(int cartid, int? id, string? platform)
        {
            return _dbContext.CartDeatails.FirstOrDefault(x => x.CartId == cartid && x.Game.Id == id && x.Platform == platform);
        }

        public async Task<List<CartDeatails>> GetCartsAsync(int userid)
        {

            return await _dbContext.CartDeatails.Include(x => x.Game).Include(x => x.Game.Screenshots).Where(x => x.Cart.UserId == userid).ToListAsync();

        }
        public async Task<CartDeatails?> FindCartById(int id)
        {
            return await _dbContext.CartDeatails.FirstOrDefaultAsync(x => x.CartDetailsId == id);

        }
        public void DeleteCart(CartDeatails cartDeatails)
        {
            _dbContext.CartDeatails.Remove(cartDeatails);
        }


        #endregion












    }
}
