using Data.ShopDbcontext;
using Domain.entities.GamePart.Game;
using Domain.IRepository.GamePart;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.GamePart;

public class GameRepository : IGameRepository
{
    #region Ctor
    private readonly GameShopDbContext _dbContext;
    public GameRepository(GameShopDbContext gameShopDbContext)
    {
        _dbContext = gameShopDbContext;
    }
    #endregion

    #region General
    public async Task<List<Game>> GamesAsync()
    {
        return await _dbContext.Games.Include(x => x.Screenshots).Include(x => x.gameSelectedPlatforms).Include(x => x.gemeSelectedGenres).Where(x => x.IsDelete == false).ToListAsync();
    }

    public async Task<Game?> GetGameById(int Id)
    {
        return await _dbContext.Games.Include(x => x.Screenshots).Include(x => x.gemeSelectedGenres).Include(x => x.Comments).FirstAsync(x => x.Id == Id);
    }

    public async Task<List<Game>> GetRelatedGamesBtGenre(Game game)
    {

        return await _dbContext.Games.Include(x => x.Screenshots).Include(x => x.gemeSelectedGenres).Where(g => g.gemeSelectedGenres
             .Any(genre => genre.GenreId == game.gemeSelectedGenres.Select(g => g.GenreId).FirstOrDefault()))
         .ToListAsync();
    }


    #endregion

    //----------------------------------
    #region Admin Side
    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
    public int GameCount()
    {
        var num = _dbContext.Games.Count();
        return num;
    }

    public async Task AddNewGame(Game game)
    {
       await _dbContext.Games.AddAsync(game);
       await SaveChanges();
    }
    #endregion
}
