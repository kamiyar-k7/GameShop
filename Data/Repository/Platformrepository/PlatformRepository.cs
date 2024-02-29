using Data.ShopDbcontext;
using Domain.entities.GamePart.Platform;
using Domain.IRepository.PlatformRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Platformrepository
{
    public class PlatformRepository : IPlatformRepository
    {
        #region Ctor
        private readonly GameShopDbContext _gameShopDbContext;
        public PlatformRepository(GameShopDbContext gameShopDbContext)
        {
                _gameShopDbContext = gameShopDbContext;
        }
        #endregion
        #region Genreal 
        public async Task<List<Platform>> GetPlatforms()
        {
            return await _gameShopDbContext.platforms.ToListAsync();
        }

        public async Task<List<Platform>> GetPlatformsById(int Id)
        {
            var plats =  await _gameShopDbContext.selectedPlatforms.Where(x => x.GameId == Id).Select(x => x.Platform).ToListAsync();
            return plats;
        }
        #endregion
    }
}
