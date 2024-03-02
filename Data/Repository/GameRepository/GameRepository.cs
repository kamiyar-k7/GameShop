
using Data.ShopDbcontext;
using Domain.entities.GamePart.Game;
using Domain.IRepository.GameRepository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.GameRepository;

public class GameRepository : IGameRepository
{
	#region Ctor
	private readonly  GameShopDbContext _dbContext;
    public GameRepository(GameShopDbContext gameShopDbContext)
    {
            _dbContext = gameShopDbContext;
    }
    #endregion

    #region General
    public async Task<List<Game>> GamesAsync()
    {
        return await  _dbContext.Games.Include(x=> x.Screenshots).Where(x=> x.IsDelete == false).ToListAsync();
    }
     public async Task<Game?> GetGameById(int id)
    {
        return await _dbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
    }
    #endregion
}
