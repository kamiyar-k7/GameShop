
using Application.Services.Interfaces.AdminSide;
using Application.ViewModel.AdminSide;
using Domain.IRepository.AccountRepositorieInterfaces;


namespace Application.Services.implements.AdminSide;

public class UsersService : IUserService
{
    #region Ctor
    private readonly IAccountRepository _account;
    private readonly ILayoutService _layoutService;
    public UsersService(IAccountRepository account, ILayoutService layoutService)
    {
        _account = account;
        _layoutService = layoutService;

    }

    #endregion


    public async Task<List<AllUsersViewModel>> ListOFUers()
    {
        var users = await _account.GetUsersAsync();

        List<AllUsersViewModel> model = new List<AllUsersViewModel>();
        foreach (var user in users)
        {
            AllUsersViewModel childmodel = new AllUsersViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Created = user.Created,
                ScreenShot = user.UserAvatar!,
            };
            model.Add(childmodel);
        }
        return model;



    }
    public async Task<UsersViewModel> UsersViewModel(int id)
    {
       
        var users = await ListOFUers();
        UsersViewModel usersViewModel = new UsersViewModel()
        {
            AllUsers = users,
            Admin = await _layoutService.AdminInfo(id),
        };

        return usersViewModel;

    }
}
