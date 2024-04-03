using Application.Services.Interfaces.UserSide;
using Application.ViewModel.UserSide;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Controllers;


public class StoreController : Controller
{
    #region Ctor
    private readonly IStoreService _storeService;
    private readonly IProductService _productService;
    private readonly ICatalogService _catalogService;

    public StoreController(IStoreService storeService,
        IProductService productService,
        ICatalogService catalogService)
    {
        _storeService = storeService;
        _productService = productService;
        _catalogService = catalogService;

    }
    #endregion

    #region Index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (ModelState.IsValid)
        {
            var games = await _storeService.ShowGames();
            if (games != null)
            {
                return View(games);
            }
            return View(null);
        }
        return View();
    }
    #endregion


    #region Catalog
    [HttpGet]
    public async Task<IActionResult> Catalog(string searchString, int? platformId, int? genreId)
    {

        var model = await _catalogService.SearchCatalog(new CatalogViewModel
        {
            search = new CatalogSearchViewModel
            {
                SearchString = searchString,
                PlatfromId = platformId,
                GenreId = genreId
            }
        });

        if (model.Games.Count != 0)
        {
            return View(model);
        }

        TempData["NullRefrence"] = "We Couldent Find Any Game By This Information in Our Stuck";
        return View(model);


    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Catalog(CatalogViewModel viewModel, string search)
    {
        

        var searchString = viewModel.search?.SearchString;
        var platformId = viewModel.search?.PlatfromId;
        var genreId = viewModel.search?.GenreId;
        if (search != null)
        {
            searchString = search;
        }


        return RedirectToAction("Catalog", new { searchString, platformId, genreId });
    }
    #endregion



    #region Product
    [HttpGet]
    public async Task<IActionResult> Product(int Id)
    {

        var Product = await _productService.GetProductById(Id , 0);

        if (Product != null)
        {

            return View(Product);
        }


        return NotFound();

    }

    [HttpPost, ValidateAntiForgeryToken, Authorize]
    public async Task<IActionResult> Product([FromForm] ProductViewModel model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (int.TryParse(userId, out int id))
        {
            // Map ProductViewModel to your service model
            var serviceModel = new CommentsViewModelProduct
            {
                UserId = id,
                GameId = model.Game.Id, 
                Title = model.Title,
                Comment = model.Comment,
                Ratings = model.Rating 
            };

           
            var success = await _productService.SubmitComment(serviceModel);

            if (success)
            {
            
                return RedirectToAction("Product", new { Id = model.Game.Id });
            }

        }
    

        
        return View(model);
    }
    #endregion


}
