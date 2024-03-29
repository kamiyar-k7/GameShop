using Application.Helpers;
using Application.Services.Interfaces.AdminSide;
using Application.ViewModel.AdminSide;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class UsersController : BaseController
{
    #region Ctor
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;
    public UsersController(IUserService userService, IAdminService admin)
    {

        _userService = userService;
        _adminService = admin;
    }
    #endregion


    #region User Part
    public async Task<IActionResult> Users()
    {

        var model = await _userService.UsersViewModel((int)HttpContext.User.GetUserId());

        ViewData["Title"] = "Users";

        return View(model);

    }
    public async Task<IActionResult> UserDetails(int Id)
    {
        var model = await _userService.UserDetail((int)HttpContext.User.GetUserId(), Id);

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> EditUser(int id)
    {
        var model = await _userService.UserDetail((int)HttpContext.User.GetUserId(), id);

        ViewData["Title"] = $"Edit User: {model.User.UserName}";
        return View(model);
    }
    [HttpPost , ValidateAntiForgeryToken]
    public  IActionResult EditUser(UserDetailViewModel model)
    {
        var details = model.User;
        var roles = model.SelectedRoles;

        var update =   _userService.EditUser(details, roles);
        if (update)
        {
            return RedirectToAction("UserDetails", new { id = details.Id });
        }
        return View(model);
    }
    #endregion

    public async Task<IActionResult> Admins()
    {

        var model = await _adminService.AdminsViewModel((int)HttpContext.User.GetUserId());
        ViewData["Title"] = "Admins";
        return View(model);
    }
}
