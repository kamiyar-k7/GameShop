using Domain.entities.Store.Game;
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
         Task<Game?> CheckGame(int id);
        Task<User> CheckUSer(string userphone);
       Task AddToCart(string userphone,Cart cart);
        Task<List<Cart>> GetListOfCart();
        Task DeleteCart(string userphone, int productid);
    }
}
