using Application.DTOs.UserSide.StorePart;
using Domain.entities.GamePart.GemSelectedGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IGenreService
    {
        #region General
        Task<List<Genre>> ShowGenre();
        Task<List<Genre>> GetGenresById(int Id);
        Task<List<StoreDto>> GetRelatedGamesByGenres(List<Domain.entities.GamePart.GemSelectedGenre.Genre> genres);
        #endregion
    }
}
