using Data.ShopDbcontext;
using Domain.entities.UserPart.User;
using Domain.IRepository.CartRepositoryInterface;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.CartRepository;

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
  
    public async Task<List<Cart>> GetListOfCart()
    {
        return await _dbContext.Users.SelectMany(x => x.UserCart).ToListAsync();
   
    }
    #endregion
}
