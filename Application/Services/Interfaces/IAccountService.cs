using Application.DTOs.UserSide.Account;
using Application.ViewModel.UserSide;


namespace Application.Services.Interfaces;

public interface IAccountService
{
    Task<SignInDto> FindUser(SignInDto model);
    Task<bool> AddToDataBase(SignUpDto model, CancellationToken cancellation);
    Task<UserAccountViewModel> UserViewModel(int id);
    Task<bool> UpdateDetails(UserDeatailViewModel model);
}
