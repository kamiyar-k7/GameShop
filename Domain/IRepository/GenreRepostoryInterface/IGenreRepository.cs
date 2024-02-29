using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.GenreRepostoryInterface
{
    public interface IGenreRepository
    {
        #region General 
        Task<List<Genre>> GetGenre();
        Task<List<Genre>> GetGenresById(int Id);
        Task<List<Game>> GetGamesByGenres(List<Genre> genres);
        #endregion
    }
}
