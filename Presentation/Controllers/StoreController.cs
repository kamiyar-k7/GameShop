using Application.Services.Interfaces;
using Application.ViewModel.UserSide;
using Microsoft.AspNetCore.Mvc;

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

        if(model.Games.Count != 0)
        {
            return View(model);
        }

        TempData["NullRefrence"] = "We Couldent Find Any Game By This Information in Our Stuck";
        return View(model);

   
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Catalog(CatalogViewModel viewModel , string search)
    {
        // Capture the search parameters
      
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

        var Product = await _productService.GetProductById(Id);

        if (Product != null)
        {

            return View(Product);
        }


        return NotFound();

    }
    #endregion


}
