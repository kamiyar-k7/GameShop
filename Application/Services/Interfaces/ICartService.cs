using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<CartDto>> ListOfCart();
        Task AddToCAart(string userphone, ProductDto model);
        Task DeleteCart(string userphone, int productid);
    }
}
