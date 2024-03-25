using Application.DTOs.UserSide.StorePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces.UserSide
{
    public interface IStoreService
    {
        #region general
        Task<List<StoreDto>> ShowGames();
        #endregion
    }
}
