using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;


public class HomeController : Controller
{
    #region Ctor

	private readonly IStoreService _storeService;

    public HomeController(  IStoreService storeService)
    {
           
		_storeService = storeService;
    }
	#endregion

	#region Index
	public async Task<IActionResult> Index()
	{
		if (ModelState.IsValid)
		{
			var games = await	_storeService.ShowGames();
			return View(games);
		}

			return View();

	}
	public IActionResult Test()
	{
		return View();
	}
	#endregion


}
