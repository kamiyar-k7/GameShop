using Application.DTOs.UserSide.Home;
using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.entities.GamePart.GemGenreDto;

using Domain.IRepository.GenreRepostoryInterface;
using Domain.IRepository.StoreRepositoryInterface;
using System.Net.Http.Headers;


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
    public async Task<List<GenreDto>> ShowGenre()
    {
        var genre = await _genreRepository.GetGenre();
        if (genre != null)
        {
            List<GenreDto> model = new List<GenreDto>();

            foreach (var genid in genre)
            {
                GenreDto childemodel = new GenreDto()
                {
                    Id = genid.Id,
                    GenreName = genid.GenreName,
                    GenreUniqueName = genid.GenreUniqueName
                };
                model.Add(childemodel);
            }
            return model;
        }
        return null;

    }

    public async Task<List<GenreDto>> GetGenresById(int Id)
    {
        var genre = await _genreRepository.GetGenresById(Id);
        if(genre != null)
        {
            List<GenreDto> model = new List<GenreDto>();

            foreach (var genid in genre)
            {
                GenreDto childemodel = new GenreDto()
                {
                    Id = genid.Id,
                    GenreName = genid.GenreName,
                    GenreUniqueName = genid.GenreUniqueName
                };
                model.Add(childemodel);
            }
            return model;
        }
        return null;
    }
    public async Task<List<StoreDto>> GetRelatedGamesByGenres(List<Domain.entities.GamePart.GemGenreDto.Genre> genres)
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
