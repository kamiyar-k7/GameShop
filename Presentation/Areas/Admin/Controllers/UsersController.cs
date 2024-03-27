using Application.Helpers;
using Application.Services.Interfaces.AdminSide;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Areas.Admin.Controllers;

public class UsersController : BaseController
{
    #region Ctor
   private readonly IUserService _userService;
    public UsersController( IUserService userService)
    {
       
        _userService = userService;
    }
    #endregion


    public async Task<IActionResult> Users()
    {

        var model = await _userService.UsersViewModel((int)HttpContext.User.GetUserId());

        ViewData["Title"] = "Users";

        return View(model);

    }
    public async Task<IActionResult> Admins()
    {
        

    }
}
