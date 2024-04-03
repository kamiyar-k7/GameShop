using Application.Helpers;
using Application.Services.Interfaces.AdminSide;
using Application.Services.Interfaces.UserSide;
using Application.ViewModel.AdminSide;
using Application.ViewModel.UserSide;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;


public class GamesController : BaseController
{
    #region Ctor
    
    private readonly IProductService _productService;
  
    public GamesController(IProductService productService )
    {
            _productService = productService;
       
    }

    #endregion

    public async Task <IActionResult> ListOfGames()
    {
        ViewData["Title"] = "List OF Games";

        var model = await _productService.ListOfProducts((int)HttpContext.User.GetUserId());
        return View(model);

    }

    public async Task<IActionResult> GameDetails()
    {
       
        var model = await _productService.ListOfProducts( (int)HttpContext.User.GetUserId());
        ViewData["Title"] = $"{model.Game.Name} Details";
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> AddGame()
    {
        

        var adminid = (int)HttpContext.User.GetUserId();
        var model = await _productService.ShowAddGame(adminid);
    
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddGame(ProductViewModel model , List<int> selectedGenres , List<int > selectedPlatforms)
    {
        // game details
        // game platforms 
        // game genres 


        return View();
    }
}
