using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    
            ViewData["Platform"] = await _platformService.ShowPlatform();
            var games = await _catalogService.ShowGames();
       
            return View(games);
        }
        return NotFound();
    }

    public async Task<IActionResult> Search(string search)
    {
        if (ModelState.IsValid)
        {

        

            return View(search);
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
                ViewData["Platforms"] = await _platformService.GetPlatformsById(Id);
             

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

    #region Search
    public async Task<IActionResult> Search()
    {
        return View();
    }
    #endregion


}
