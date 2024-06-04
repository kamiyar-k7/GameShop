using Application.DTOs.UserSide.StorePart;
using Domain.entities.GamePart.GemGenreDto;
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
        Task<List<GenreDto>> ShowGenre();
        Task<List<GenreDto>> GetGenresById(int Id);
        Task<List<StoreDto>> GetRelatedGamesByGenres(List<Domain.entities.GamePart.GemGenreDto.Genre> genres);
        #endregion
    }
}
