using Domain.entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.CatalogRepository
{
    public interface ICatalogRepository
    {
        #region General
        Task<List<Game>> GetListOfGames();
        #endregion
    }
}
