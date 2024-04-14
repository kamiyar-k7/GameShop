using Domain.entities.Cart;



namespace Domain.IRepository.UserPart;

public interface ICartRepository
{
    Task SaveChanges();
    Task AddToCart(CartDeatails cartDeatails);
    Task AddUserCartToCarts(Carts carts);
    Task<List<CartDeatails>> GetCartItems(int userid);
    Task<CartDeatails?> FindCartDetailsById(int id);
    Task<Carts> GetCArtByUserId(int id);
    void DeleteCart(CartDeatails cartDeatails);
     Task AddLocation(Location location);
    CartDeatails? IsGameExistInCart(int cartid, int? id, string? platform);
    Task AddOneMoreToCart(CartDeatails cartDeatails);
    Task FinalOrder(Carts cart);

    #region Admin 
    Task<List<Carts>> GetListOfORders();
    Task<List<CartDeatails>> GetOrderDetails(int id);
     Task<Carts?> GetOrderById(int id);
    Task UpdateOrderStatus(Carts carts);
    #endregion
}
