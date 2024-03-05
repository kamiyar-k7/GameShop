using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


public class StoreController : Controller
{
    #region Ctor
    private readonly IStoreService _storeService;
    private readonly IProductService _productService;
    private readonly ICatalogService _catalogService;
    private readonly IPlatformService _platformService;
    private readonly IGenreService _genreService;
    public StoreController(IStoreService storeService,
        IProductService productService,
        ICatalogService catalogService,
        IPlatformService platformService,
        IGenreService genreService)
    {
        _storeService = storeService;
        _productService = productService;
        _catalogService = catalogService;
        _platformService = platformService;
        _genreService = genreService;
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
    public async Task<IActionResult> Catalog()
    {
        if (ModelState.IsValid)
        {

            var model = await _catalogService.GetCatalogAsync();

            return View(model);
        }
        return NotFound();
    }
    #endregion


    #region Product
    [HttpGet]
    public async Task<IActionResult> Product(int Id )
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
