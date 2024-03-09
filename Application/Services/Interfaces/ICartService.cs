
using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;
using Application.ViewModel.UserSide;

namespace Application.Services.Interfaces;

public interface ICartService
{

    Task<List<CartDto>> ShowListOfCart(int userid);
    Task AddToCart(ProductViewModel model, int userid);
    Task<bool> DeleteCart(int id);
     Task<CheckOutViewModel> CheckOut(int user);
}
