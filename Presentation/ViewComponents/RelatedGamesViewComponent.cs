
using Application.Services.implements;
using Application.Services.Interfaces;
using Domain.entities.Store.Game;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class RelatedGamesViewComponent : ViewComponent
{
    #region Ctor
    private readonly IStoreService _storeService;
    private readonly IGenreService _genreService;
    private readonly IProductService _productService;

    public RelatedGamesViewComponent(IStoreService storeService, IGenreService genreService, IProductService productService)
    {
        _storeService = storeService;
        _genreService = genreService;
        _productService = productService;
    }
    #endregion


    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("RelatedGames", await _storeService.ShowGames());
    }
}


