using Domain.entities.GamePart.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.PlatformRepositoryInterface
{
    public interface IPlatformRepository
    {
        #region General

        Task<List<Platform>> GetPlatforms();
        Task<List<Platform>> GetPlatformsById(int Id);
        #endregion
    }
}
