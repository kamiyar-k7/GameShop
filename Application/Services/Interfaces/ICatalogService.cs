using Application.DTOs.UserSide.StorePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ICatalogService
    {
        #region General
        Task<List<CatalogDto>> ShowGames();
        #endregion
    }
}
