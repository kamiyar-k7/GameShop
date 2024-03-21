using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.entities.GamePart.Genre;
using Domain.IRepository.GenreRepostoryInterface;



namespace Application.Services.implements;

public class GenreService : IGenreService
{
    #region Ctor
    private readonly IGenreRepository _genreRepository;
    public GenreService(IGenreRepository genreRepository)
    {
            _genreRepository = genreRepository;
    }
    #endregion

    #region General
    public async Task<List<Genre>> ShowGenre()
    {
        return await _genreRepository.GetGenre();

    }

    public async Task<List<Genre>> GetGenresById(int Id)
    {
        return await _genreRepository.GetGenresById(Id);
    }
    public async Task<List<StoreDto>> GetRelatedGamesByGenres(List<Genre> genres)
    {
        var relatedGames = await _genreRepository.GetGamesByGenres(genres); 
    
        return relatedGames.Select(game => new StoreDto 
        { 
         Name = game.Name,
         Id = game.Id,
         Description = game.Description,
         Price  = game.Price,
         Rating = game.Rating , 
         ReleaseDate = game.ReleaseDate ,
         Screenshots = new List<string>(),
         Trailer = game.Trailer
         
         
        }).ToList();
    }
    #endregion
}
