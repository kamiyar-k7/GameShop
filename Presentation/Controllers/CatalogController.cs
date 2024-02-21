using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CatalogController : Controller
    {
        #region Ctor
        private readonly ICatalogService _catalogService;
        private readonly IGenreService _genreService;
        private readonly IPlatformService _platformService;
        public CatalogController(ICatalogService catalogService, IGenreService genreService, IPlatformService platformService)
        {
            _catalogService = catalogService;
            _genreService = genreService;
            _platformService = platformService;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            if (ModelState.IsValid)
            {
                var games = await _catalogService.ShowGames();
                if (games == null)
                {
                    return View(null);

                }
                else
                {
                    ViewData["Genre"] = await _genreService.ShowGenre();
                    ViewData["Platform"] = await _platformService.ShowPlatform();

                    return View(games);
                }

            }
            return View();
        }
    }
}
