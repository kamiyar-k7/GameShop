using Domain.entities.GamePart.GemSelectedGenre;
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
        #endregion
    }
}
