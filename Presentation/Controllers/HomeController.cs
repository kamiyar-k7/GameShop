using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;


public class HomeController : Controller
{
    #region Ctor
    private readonly IHomeService _homeService;

    public HomeController( IHomeService homeService)
    {
            _homeService = homeService;
    }
	#endregion

	#region Index
	public async Task<IActionResult> Index()
	{
		if (ModelState.IsValid)
		{
			var games = await	_homeService.ShowGames();
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
