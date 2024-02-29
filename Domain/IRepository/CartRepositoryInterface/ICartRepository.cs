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
        Task<List<Cart>> GetListOfUserCart(int id);
        Task AddToCart(Cart cart);
    }
}
