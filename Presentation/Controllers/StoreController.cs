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

    #region Search (catalog)
    //[HttpGet]
    //public async Task<IActionResult> Catalog(CatalogViewModel model)
    //{
    //    return View();
    //}
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
