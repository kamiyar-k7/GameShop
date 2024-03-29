﻿
using Application.ViewModel.AdminSide;

namespace Application.Services.Interfaces.AdminSide;

public interface IUserService
{
   
    Task<UsersViewModel> UsersViewModel(int id);
    Task<UserDetailViewModel> UserDetail(int AdminId, int UserId);
    bool EditUser(OneUserViewModel details, List<UserRolesVeiwModel> roles);
}
