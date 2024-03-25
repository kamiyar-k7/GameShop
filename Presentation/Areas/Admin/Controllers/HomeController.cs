using Application.Helpers;
using Application.Services.Interfaces.AdminSide;
using Application.ViewModel.AdminSide;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class HomeController : BaseController
{

    #region Ctor
   
     private readonly IAdminHomeService _homeservices;
    private readonly ILayoutService _layoutService;
    public HomeController(IAdminHomeService dashbord , ILayoutService layoutService)
    {
        _homeservices = dashbord;
         _layoutService = layoutService;
     
    }
    #endregion

    public async Task <AdminBaseViewModel> layout()
    {

        var userid = (int)HttpContext.User.GetUserId();
        var info = await _layoutService.AdminInfo(userid);
        AdminBaseViewModel adminBaseViewModel = new AdminBaseViewModel()
        {
            Admin = info
        };

        return adminBaseViewModel;
    }

    public async Task<IActionResult> Index()   
	{


         var admin = await layout();

        AdminHomeViewModel model = new AdminHomeViewModel()
        {
            counts = _homeservices.DashboardView(),
            Admin = admin.Admin,

        };


        ViewData["Title"] = "Dashboard";

        return View(model);

	}

    public async Task<IActionResult> ContactUs()
    {
        var admin = await layout();
        var contact = await _homeservices.Messages();

        AdminHomeViewModel model = new AdminHomeViewModel()
        {

            Admin = admin.Admin,
            contactMessages = contact

        };
        

        ViewData["Title"] = "Contact Page";

        return View(model);
    }

    public async Task< IActionResult> DeleteMessage(int id)
    {
        var res = await _homeservices.DeleteMessage(id);
        if(res)
        {
            return RedirectToAction(nameof(ContactUs));
        }
        ViewData["ErrorMessage"] = "something Wrong Pleas Try Agin Later";
        return RedirectToAction(nameof(ContactUs));
    }

    public async Task<IActionResult> AboutUs()
    {
        return View();
    }

}
