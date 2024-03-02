using Application.DTOs.UserSide.Home;
using Application.Services.Interfaces;
using Domain.IRepository.GameRepository;


namespace Application.Services.implements;



public class HomeService : IHomeService
{
    #region Ctor
    private readonly IGameRepository _gameRepository;
    public HomeService(IGameRepository gameRepository)
    {

        _gameRepository = gameRepository;
    }
    #endregion
    public async Task<List<HomeDto>> ShowGames()
    {
        var listofgames = await _gameRepository.GamesAsync();
        if (listofgames != null)
        {
            List<HomeDto> model = new List<HomeDto>();
            foreach (var game in listofgames)
            {


                HomeDto childmodel = new HomeDto()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Description = game.Description,
                    Price = game.Price,
                    Rating = game.Rating,
                    Trailer = game.Trailer,
                    Screenshots = new List<string>(),
                    ReleaseDate = game.ReleaseDate,
                   
                   
                };
                foreach (var screenshot in game.Screenshots)
                {
                    childmodel.Screenshots.Add(screenshot.AvararUrl);
                }


               
                model.Add(childmodel);
            }
            return model;
        }
        return null;
    }

}
