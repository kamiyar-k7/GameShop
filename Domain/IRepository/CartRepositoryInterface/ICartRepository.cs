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
        Task<List<Carts>> GetListOfUserCart(int id);
        Task<Carts> GetcartByUserId(int userid);
        Task AddToCart(CartDeatails cartDeatails);
        //Task<Game> GetGameAsync(int id);
        Task AddUserCartToCarts(Carts carts);
    }
}
