
using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;

namespace Application.Services.Interfaces;

public interface ICartService
{

    Task<List<CartDto>> ShowListOfCart(int userid);
    Task AddToCart(ProductDto model, int userid);
    Task<bool> DeleteCart(int id);
}
