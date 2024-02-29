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
        //public async Task<List<Cart>> GetListOfUserCart()
        //{
        //    return await _dbContext.Users.Include(x=> x.UserCart).Where(x=> x.).ToListAsync();
        //}
        #endregion
    }
}
