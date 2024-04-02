using Application.Services.Interfaces.UserSide;
using Domain.entities.GamePart.Platform;
using Domain.IRepository.GamePart;

namespace Application.Services.implements.SitteSide;

public class PlatformService : IPlatformService
{
    #region Ctor
    private readonly IPlatformRepository _platformInterface;
    public PlatformService(IPlatformRepository platformInterface)
    {
        _platformInterface = platformInterface;
    }
    #endregion

    #region General 
    public async Task<List<Platform>> ShowPlatform()
    {
        return await _platformInterface.GetPlatforms();
    }

    public async Task<List<Platform>> GetPlatformsById(int Id)
    {
        return await _platformInterface.GetPlatformsById(Id);

    }
    #endregion
}
