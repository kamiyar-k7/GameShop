using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class StoreController : Controller
{
    #region Ctor
    private readonly IStoreService _storeService;
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
            
    }
    #endregion
    #region Index
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

}
