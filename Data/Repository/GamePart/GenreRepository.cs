using Data.ShopDbcontext;
using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using Domain.IRepository.GamePart;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.GamePart;

public class GenreRepository : IGenreRepository
{
    #region Ctor
    private readonly GameShopDbContext _gameShopDbContext;
    public GenreRepository(GameShopDbContext gameShopDbContext)
    {
        _gameShopDbContext = gameShopDbContext;
    }
    #endregion

    #region general 
    public async Task<List<Genre>> GetGenre()
    {
        return await _gameShopDbContext.Genres.ToListAsync();

    }
    public async Task<List<Genre>> GetGenresById(int Id)
    {
        return await _gameShopDbContext.SelectedGenres.Where(x => x.GameId == Id).Select(x => x.Genre).ToListAsync();
    }
    public async Task<List<Game>> GetGamesByGenres(List<Genre> genres)
    {
        var games = await _gameShopDbContext.Games.Where(game => game.gemeSelectedGenres.Any(selectedGenre => genres.Select(g => g.Id).Contains(selectedGenre.GenreId)))
       .ToListAsync();
        return games;
    }
    public async Task AddSelectedGenres(GemeSelectedGenre gemeSelectedGenre)
    {
        await _gameShopDbContext.AddAsync(gemeSelectedGenre);
    }

    public async Task<List<GemeSelectedGenre>> GameSelectedGenre(int id)
    {
        return await _gameShopDbContext.SelectedGenres.Where(x => x.GameId == id).ToListAsync();

    }

    public void DeleteGameGenres(List<GemeSelectedGenre> gemeSelectedGenres)
    {
        _gameShopDbContext.RemoveRange(gemeSelectedGenres);
    }
    #endregion
}
