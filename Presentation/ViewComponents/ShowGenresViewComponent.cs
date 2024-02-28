using Application.Services.implements;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;


[ViewComponent(Name = "ShowGenres")]
public class ShowGenresViewComponent : ViewComponent
{

	#region Ctor
	private readonly IGenreService _genreService;
    public ShowGenresViewComponent(IGenreService genreService)
    {
            _genreService = genreService;
    }
    #endregion

    public async Task<IViewComponentResult> InvokeAsync(int? Id = null)
    {
        if (Id.HasValue)
        {
            return View("GenresByIdViewComponent", await _genreService.GetGenresById(Id.Value));
        }
        else
        {
            return View("ShowGenres", await _genreService.ShowGenre());
        }
    }
}
