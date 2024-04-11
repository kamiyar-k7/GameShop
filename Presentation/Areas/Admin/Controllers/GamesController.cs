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
    private readonly IplatfromsService _platfromservice;
    private readonly IgenreService _genreService;

    public GamesController(IProductService productService , IplatfromsService iplatfromsService , IgenreService genreService)
    {
        _productService = productService;
        _platfromservice = iplatfromsService;
        _genreService = genreService;
    }

    #endregion

    public async Task<IActionResult> ListOfGames()
    {
        ViewData["Title"] = "List OF Games";

        var model = await _productService.ListOfProducts((int)HttpContext.User.GetUserId());
        return View(model);

    }

    public async Task<IActionResult> GameDetails(int id)
    {

        var model = await _productService.GetProductById(id, (int)HttpContext.User.GetUserId());
        ViewData["Title"] = $"{model.Game.Name} Details";
        return View(model);
    }

    #region Addgame 
    [HttpGet]
    public async Task<IActionResult> AddGame()
    {

        var adminid = (int)HttpContext.User.GetUserId();
        var model = await _productService.ShowAddGame(adminid);

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddGame(ProductViewModel model, List<int> selectedGenres, List<int> selectedPlatforms)
    {

        var res = await _productService.AddNewGame(model.Game, selectedGenres, selectedPlatforms);
        if (res)
        {
            return RedirectToAction(nameof(ListOfGames));

        }

        return RedirectToAction(nameof(AddGame));



    }
    #endregion

    #region Edit game 
    [HttpGet]
    public async Task<IActionResult> EditGame(int id)
    {

        if (id != 0 && id != null)
        {
            var game = await _productService.GetProductById(id, (int)HttpContext.User.GetUserId());
            ViewData["title"] = $"Editing {game.Game.Name}";
            return View(game);

        }
        ViewData["NullId"] = "ID Is Incoorect";
        return RedirectToAction(nameof(ListOfGames));


    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditGame(ProductViewModel model, List<int> selectedGenres, List<int> selectedPlatforms, int selectedStatus)
    {
        await _productService.EditGame(model.Game, selectedGenres, selectedPlatforms);

        return RedirectToAction("GameDetails", "Games", new { id = model.Game.Id });
    }
    #endregion

    public async Task<IActionResult> DeleteScreenShot(int id)
    {
        return View();
    }

    #region Platforms

    public async Task<IActionResult> ListOfPlatforms()
    {

        var model = await _platfromservice.ListOfPLatforms((int)HttpContext.User.GetUserId()) ;
       if(model.ListOfPlats != null)
        {
            return View(model);
        }
       return View();
          
        
  
    }

    [HttpGet]
    public async Task<IActionResult> AddNewPlatform()
    {
       var model = await _platfromservice.ShowAddNewPalform((int)HttpContext.User.GetUserId());
        return View(model);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddNewPlatform(AdminPlatformsViewModel model)
    {
        await _platfromservice.AddNewPlatform(model.Platform);

        return RedirectToAction(nameof(ListOfPlatforms));
    }

    [HttpGet]
    public async Task<IActionResult> EditPlatform(int id)
    {
        var model = await _platfromservice.GetPlatformById(id , (int)HttpContext.User.GetUserId());
        return View(model);

    }

    [HttpPost ,ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPlatform(AdminPlatformsViewModel model )
    {
        await _platfromservice.UpdatePlatform(model.Platform);
        return RedirectToAction(nameof(ListOfPlatforms));
    }

    public async Task<IActionResult> RemovePlatform(int id )
    {
        await _platfromservice.RemovePlatfrom(id);

        return RedirectToAction(nameof(ListOfPlatforms));
    }
    #endregion

    #region Genres

    public async Task<IActionResult> ListOfGenres()
    {
        var model = await _genreService.ListOfGenres((int)HttpContext.User.GetUserId());
        if(model.ListOfGenres != null)
        {

          return View(model);
        }
        return View();
    }

    // addd genre
    [HttpGet]
    public async Task<IActionResult> AddNewGenre()
    {
        var model = await _genreService.ShowAddGenreView((int)HttpContext.User.GetUserId());
        return View(model);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddNewGenre(AdminGenresViewModel model)
    {
        await _genreService.AddNewGenre(model.genre);
        return RedirectToAction(nameof(ListOfGenres));


    }

    // edit genre
    [HttpGet]
    public async Task<IActionResult> EditGenre(int id)
    {
        var model = await _genreService.GetGenreById(id , (int)HttpContext.User.GetUserId());
        return View(model);
    }
    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> EditGenre(AdminGenresViewModel model)
    {
        await _genreService.EditGenre(model.genre);
        return RedirectToAction(nameof(ListOfGenres));
    }


    // remove genre 
    public async Task<IActionResult> RemoveGenre(int id)
    {
        await _genreService.RemoveGenre(id);
        return RedirectToAction(nameof(ListOfGenres));
    }
    #endregion
}
