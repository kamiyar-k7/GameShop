using Domain.entities.GamePart.Platform;
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
        Task<List<Platform>> GetPlatformsById(int Id);
        #endregion
    }
}
