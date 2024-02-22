using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


public class StoreController : Controller
{
    #region Ctor
    private readonly IStoreService _storeService;
    private readonly IProductService _productService;
    private readonly ICatalogService _catalogService;
    public StoreController(IStoreService storeService, IProductService productService, ICatalogService catalogService)
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
    public async Task<IActionResult> Catalog()
    {
        if (ModelState.IsValid)
        {
            var games = await _catalogService.ShowGames();
            return View(games);
        }
        return NotFound();
    }
    #endregion
    #region Product
    [HttpGet]
    public async Task<IActionResult> Product(int Id)
    {
        if (ModelState.IsValid)
        {
            var game = await _productService.GetProductById(Id);
            if (game != null)
            {
                return View(game);
            }
            else
            {
                return NotFound();
            }
        }
        return NotFound();

    }
    #endregion


}
