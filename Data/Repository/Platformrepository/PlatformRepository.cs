using Data.ShopDbcontext;
using Domain.entities.GamePart.Platform;
using Domain.IRepository.PlatformRepositoryInterface;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.Platformrepository;

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
        return await _gameShopDbContext.Platforms.ToListAsync();
    }

    public async Task<List<Platform>> GetPlatformsById(int Id)
    {
        var plats =  await _gameShopDbContext.SelectedPlatforms.Where(x => x.GameId == Id).Select(x => x.Platform).ToListAsync();
        return plats;
    }
    public async Task<Platform?> GetSelectedPlatform(int id)
    {
        return await _gameShopDbContext.SelectedPlatforms.Where(x => x.PlatformId == id).Select(x => x.Platform).FirstOrDefaultAsync();
    }
    #endregion
}
