using Domain.entities.Cart;
using Domain.entities.GamePart.Game;
using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.CartRepositoryInterface
{
    public interface ICartRepository
    {
        Task SaveChanges();
        Task AddToCart(CartDeatails cartDeatails);
        Task AddUserCartToCarts(Carts carts);
        Task<List<CartDeatails>> GetCartsAsync(int userid);
        Task<CartDeatails?> FindCartById(int id);
         void DeleteCart(CartDeatails cartDeatails);
        CartDeatails? IsGameExistInCart(int cartid,int? id, string? platform);
        Task AddOneMoreToCart(CartDeatails cartDeatails);
    }
}
