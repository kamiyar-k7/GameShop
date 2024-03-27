
using Application.ViewModel.AdminSide;

namespace Application.Services.Interfaces.AdminSide;

public interface IUserService
{
    Task<List<AllUsersViewModel>> ListOFUers();
    Task<UsersViewModel> UsersViewModel(int id);
}
