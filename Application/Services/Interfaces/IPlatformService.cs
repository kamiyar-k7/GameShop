using Domain.entities.GamePart.Paltform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IPlatformService
    {
        #region General
        Task<List<Platform>> ShowPlatform();
        #endregion
    }
}
