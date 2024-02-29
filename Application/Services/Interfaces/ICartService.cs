
using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;

namespace Application.Services.Interfaces;

public interface ICartService
{
    Task<List<CartDto>> GetUserCart(int id);
    Task AddToCart(ProductDto model, int userid);
}
