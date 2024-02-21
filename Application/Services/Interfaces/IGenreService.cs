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
        #endregion
    }
}
