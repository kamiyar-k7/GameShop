using Application.Helpers;
using Application.Services.Interfaces.UserSide;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;


public class GamesController : BaseController
{
    #region Ctor
    private readonly IProductService _productService;
    public GamesController(IProductService productService)
    {
            _productService = productService;
    }

    #endregion

    public async Task <IActionResult> ListOfGames()
    {
        ViewData["Title"] = "ListOFGames";

        var model = await _productService.ListOfProducts((int)HttpContext.User.GetUserId());
        return View(model);

    }
}
