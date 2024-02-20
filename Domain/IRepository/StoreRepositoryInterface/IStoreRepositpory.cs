using Domain.entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.StoreRepositoryInterface
{
    public interface IStoreRepositpory
    {
        #region general
        Task<List<Game>> GetListOfGames();
        #endregion

    }
}
