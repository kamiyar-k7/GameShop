using Data.ShopDbcontext;
using Domain.entities.Store.Game;
using Domain.entities.UserPart.User;
using Domain.IRepository.CartRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System.Transactions;



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

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
  
    public async Task<List<Cart>> GetListOfCart()
    {
        return await _dbContext.Users.SelectMany(x => x.UserCart).ToListAsync();
   
    }
    public async Task<Game?> CheckGame(int id)
    {
        return await _dbContext.games.Include(x=>x.Screenshots).FirstOrDefaultAsync(x=>x.Id == id);
    }
    public async Task<User> CheckUSer(string userphone)
    {
      
       
        return null;
    }
    public async Task AddToCart(string userphone , Cart cart )
    {
        if(cart != null)
        {
           
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=> x.PhoneNumber == userphone);

            user.UserCart.Add(cart);
        }
        else
        {
            throw new Exception();
        }
      
    }
    public async  Task DeleteCart(string userphone , int productid)
    {
       var user = _dbContext.Users.Include(x=> x.UserCart).FirstOrDefault(x=>x.PhoneNumber == userphone);
        if(user != null)
        {
            var cartItem = user.UserCart.FirstOrDefault(x => x.Id == productid);
            if(cartItem != null)
            {
                user.UserCart.Remove(cartItem);
            }
        }
    }   
    #endregion
}
