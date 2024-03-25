

using Application.Services.Interfaces.AdminSide;
using Application.Services.Interfaces.UserSide;
using Application.ViewModel.AdminSide;

namespace Application.Services.implements.AdminSide;

public class LayoutService : ILayoutService
{
	#region Ctor
	private readonly IAccountService _account;
    public LayoutService(IAccountService accountService)
    {
            
         _account = accountService;
    }
    #endregion

    public async Task<AdminInformationViewModel> AdminInfo(int id)
    {
        var admin = await _account.AdminInfoView(id);

        AdminInformationViewModel adminmodel = new AdminInformationViewModel()
        {
            Id = admin.Id,
            DateTime = admin.DateTime,
            Email = admin.Email,
            PhoneNumber = admin.PhoneNumber,
            UserAvatar = admin.UserAvatar,
            UserName = admin.UserName,
        };


        return adminmodel; 
    } 
}
