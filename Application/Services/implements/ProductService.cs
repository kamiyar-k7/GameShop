using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Application.ViewModel.UserSide;
using Domain.entities.GamePart.Game;
using Domain.IRepository.GameRepositoryInteface;
using Domain.IRepository.GenreRepostoryInterface;
using Domain.IRepository.PlatformRepositoryInterface;
using Domain.IRepository.ProductRepositoryInterface;


namespace Application.Services.implements;

public class ProductService : IProductService
{
    #region Ctor
    private readonly IGameRepository _gamerepository;
    private readonly IPlatformRepository _platformRepository;
    private readonly IGenreRepository _genreRepository;

    public ProductService(IGameRepository gameRepository, IPlatformRepository platformRepository, IGenreRepository genreRepository)
    {
        _gamerepository = gameRepository;
        _platformRepository = platformRepository;
        _genreRepository = genreRepository;
    }
    #endregion

    #region General 



    public async Task<ProductViewModel> GetProductById(int Id)
    {

        var Game = await _gamerepository.GetGameById(Id);
        var platforms = await _platformRepository.GetPlatformsById(Id);
        var Genres = await _genreRepository.GetGenresById(Id);
        var related = await _gamerepository.GetRelatedGamesBtGenre(Game);

        if (Game != null)
        {

            ProductViewModel model = new ProductViewModel()
            {
                Games = Game,
                Platforms = platforms,
                Genres = Genres,
                RelatedGames = new List<Game>()

            };
            foreach (var item in Game.Screenshots)
            {
                model.Games.Screenshots.Add(item);

            }
            if(related != null)
            {
               
              
                model.RelatedGames.AddRange(related);
            }
       
            return model;

        }
        return null;
    }

    #endregion
}
