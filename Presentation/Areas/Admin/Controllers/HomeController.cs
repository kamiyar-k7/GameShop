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



    public async Task<IActionResult> Index()   
	{



        var model = await _homeservices.HomeAdminVeiwModel((int)HttpContext.User.GetUserId());
            

        ViewData["Title"] = "Dashboard";

        return View(model);

	}


    public async Task<IActionResult> ContactUs()
    {

        var model = await _homeservices.ContactService((int)HttpContext.User.GetUserId());
        

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
        ViewData["ErrorMessage"] = "something Wrong Please Try Agin Later";
        return RedirectToAction(nameof(ContactUs));
    }


    // not finished
    public async Task<IActionResult> AboutUs()
    {
        var admin = await _layoutService.AdminInfo((int)HttpContext.User.GetUserId());
        AdminHomeViewModel model = new AdminHomeViewModel()
        {

            Admin = admin,
          
        };

        
        ViewData["Title"] = "Contact Page";

        return View(model);
    }

}
