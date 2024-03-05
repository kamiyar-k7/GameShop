using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Application.ViewModel.UserSide;
using Domain.entities.GamePart.Game;
using Domain.IRepository.CatalogRepositoryInterface;
using Domain.IRepository.GameRepository;
using Domain.IRepository.GenreRepostoryInterface;
using Domain.IRepository.PlatformRepositoryInterface;


namespace Application.Services.implements;

public class CatalogService : ICatalogService
{
    #region Ctor

    private readonly IGameRepository _gameRepository;
    private readonly IPlatformRepository _platformRepository;
    private readonly IGenreRepository _genreRepository;
    public CatalogService(IGameRepository gameRepository, IPlatformRepository platform , IGenreRepository genreRepository)
    {

        _gameRepository = gameRepository;
        _platformRepository = platform;
        _genreRepository = genreRepository;
    }
    #endregion



    #region Genreal
    public async Task<CatalogViewModel> GetCatalogAsync()
    {
        var listOfGames = await _gameRepository.GamesAsync();
        var listOfPlatforms = await _platformRepository.GetPlatforms();
        var genrelist = await _genreRepository.GetGenre();
        if (listOfGames != null && listOfPlatforms != null)
        {
            var model = new CatalogViewModel
            {
                games = new List<Game>(),
                platforms = listOfPlatforms.ToList(),
                Genres = genrelist.ToList(),
                
            };

            foreach (var game in listOfGames)
            {
                var gameModel = new Game
                {
                    Id = game.Id,
                    Name = game.Name,
                    Description = game.Description,
                    Price = game.Price,
                    Rating = game.Rating,
                    ReleaseDate = game.ReleaseDate,
                    Screenshots = game.Screenshots.ToList()
                };
                model.games.Add(gameModel);
            }

            return model;
        }
        return null;
    }

    #endregion

}