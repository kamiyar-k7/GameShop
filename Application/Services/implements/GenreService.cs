using Application.Services.Interfaces;
using Domain.entities.GamePart.GemSelectedGenre;

using Domain.IRepository.GenreRepostoryInterface;


namespace Application.Services.implements
{
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
            var genre =  await _genreRepository.GetGenre();
            return genre;
        }
        #endregion
    }
}
