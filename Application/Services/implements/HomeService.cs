

using Application.DTOs.UserSide.Home;
using Application.Services.Interfaces;
using Domain.IRepository.HomeRepositoryInterface;

namespace Application.Services.implements;



public class HomeService : IHomeService
{
    #region Ctor
    private readonly IHomeRepository _homeRepository;
    public HomeService(IHomeRepository homeRepository)
    {
            _homeRepository = homeRepository;
    }
    #endregion
    public async Task<List<HomeDto>> ShowGames()
    {
        var listofgames = await _homeRepository.GetListOfGames();
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
                    Screenshots = new List<string>()
                   
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
