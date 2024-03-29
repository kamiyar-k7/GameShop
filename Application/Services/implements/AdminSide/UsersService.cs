
using Application.Services.Interfaces.AdminSide;
using Application.Services.Interfaces.UserSide;
using Application.ViewModel.AdminSide;
using Domain.IRepository.AccountRepositorieInterfaces;
using Domain.entities.UserPart.User;

namespace Application.Services.implements.AdminSide;

public class UsersService : IUserService
{
    #region Ctor
    private readonly IAccountRepository _account;
    private readonly ILayoutService _layoutService;
    private readonly IRoleService _roleservice;
    public UsersService(IAccountRepository account, ILayoutService layoutService , IRoleService roleService)
    {
        _account = account;
        _layoutService = layoutService;
        _roleservice = roleService;

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

    public async Task<OneUserViewModel> FillUser(int id)
    {
        var user = await _account.GetUserByIdAsync(id);

        OneUserViewModel model = new OneUserViewModel()
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Created = user.Created,
            UserAvatar = user.UserAvatar!,
        };

        return model;
    }
    
    public async Task<List< UserRolesVeiwModel>> UserRoles(int id)
    {
		var roles = await _roleservice.GetUserRoles(id);
        List<UserRolesVeiwModel> model = new List<UserRolesVeiwModel>();

        foreach (var role1 in roles)
        {
			UserRolesVeiwModel childmodel = new UserRolesVeiwModel()
			{
				Id = role1.Id,
				RoleName = role1.RoleTitle,
			};
            model.Add(childmodel);
		}
	

        return model;

    }

    public async Task<UserDetailViewModel > UserDetail(int AdminId , int UserId)
    {
        var admin = await _layoutService.AdminInfo(AdminId);
        var user = await FillUser(UserId);
        var roles = await UserRoles(UserId);
        UserDetailViewModel model = new UserDetailViewModel()
        {
            Admin = admin,
            User = user,
          SelectedRoles = roles,
        };

        return model;
    }

    public bool EditUser(OneUserViewModel details, List< UserRolesVeiwModel> roles)
    {
        var user =  _account.finduser(details.Id);

           user.UserName = details.UserName;
        user.Email = details.Email;    
        
        _account.EditUser(user);
        return true;
        
    }
    

    
}
