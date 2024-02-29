
using Data.ShopDbcontext;
using Domain.entities.GamePart.Game;
using Domain.IRepository.HomeRepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.HomeRepository;

public class HomeRepository : IHomeRepository
{
    #region Ctor
    private readonly GameShopDbContext _gameShopDbContext;
    public HomeRepository(GameShopDbContext gameShopDbContext)
    {
        _gameShopDbContext = gameShopDbContext;
            
    }

    #endregion

    #region general 

    public async Task<List<Game>> GetListOfGames()
    {
        return await _gameShopDbContext.games
     .Include(x=> x.Screenshots)
     .ToListAsync();
    }
    #endregion
}
