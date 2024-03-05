
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
  
    public async Task<Game?> GetGameById(int Id)
    {
        return await _dbContext.Games.Include(x => x.Screenshots).Include(x=> x.gemeSelectedGenres).FirstAsync(x => x.Id == Id);
    }
    public async Task<List<Game>> GetRelatedGamesBtGenre(Game game)
    {

        return await _dbContext.Games.Include(x=> x.Screenshots).Include(x => x.gemeSelectedGenres).Where(g => g.gemeSelectedGenres
             .Any(genre => genre.GenreId == game.gemeSelectedGenres.Select(g => g.GenreId).FirstOrDefault()))
         .ToListAsync();
    }
    #endregion
}
