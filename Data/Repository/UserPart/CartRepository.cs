
using Data.ShopDbcontext;
using Domain.entities.Cart;
using Domain.IRepository.UserPart;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.UserPart;

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
    public async Task<List<CartDeatails>> GetCartItems(int userid)
    {

        return await _dbContext.CartDeatails.Include(x => x.Game).Include(x => x.Game.Screenshots).Where(x => x.Cart.UserId == userid && x.Cart.IsFinally == false).ToListAsync();

    }
    public async Task<CartDeatails?> FindCartDetailsById(int id)
    {
        return await _dbContext.CartDeatails.FirstOrDefaultAsync(x => x.CartDetailsId == id);

    }
    public async  Task<Carts> GetCArtByUserId(int id)
    {
        return await _dbContext.Cart.Include(x=> x.CartDeatails).Where(x=> x.UserId == id).FirstAsync();
    }
    public async Task AddLocation(Location location)
    {
        await _dbContext.Locations.AddAsync(location);
        await SaveChanges();
    }
    public void DeleteCart(CartDeatails cartDeatails)
    {
        _dbContext.CartDeatails.Remove(cartDeatails);
    }

    public async Task FinalOrder(Carts cart)
    {
         _dbContext.Update(cart);
        await SaveChanges();
    }

    #endregion

    #region Admin
    public async Task<List<Carts>> GetListOfORders()
    {
        return await _dbContext.Cart.Where(x=> x.IsFinally == true).ToListAsync();
    }
    public async Task<List<CartDeatails>> GetOrderDetails(int id)
    {
     return   await _dbContext.CartDeatails.Include(x=> x.Game).ThenInclude(x=> x.Screenshots).Where(x=> x.CartDetailsId == id).ToListAsync();

    }
    public async Task<Carts?> GetOrderById(int id)
    {
        return await _dbContext.Cart.FindAsync(id);
    }

    public async Task UpdateOrderStatus(Carts carts)
    {
         _dbContext.Update(carts);
        await SaveChanges();
    }
    #endregion



}
