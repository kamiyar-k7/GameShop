using Domain.entities.GamePart.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.CatalogRepositoryInterface
{
    public interface ICatalogRepository
    {
        #region General
        Task<List<Game>> GetListOfGames();
        #endregion
    }
}
