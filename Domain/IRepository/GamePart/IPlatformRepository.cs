using Domain.entities.GamePart.Platform;

namespace Domain.IRepository.GamePart;

public interface IPlatformRepository
{
    #region General

    Task<List<Platform>> GetPlatforms();
    Task<List<Platform>> GetPlatformsById(int Id);
    Task<Platform?> GetSelectedPlatform(int id);
    Task AddselectedPlats(GameSelectedPlatform platforms);
    Task<List<GameSelectedPlatform>> GameSelectedPlatforms(int id);



    void DeleteGamePlatforms(List<GameSelectedPlatform> gameSelectedPlatforms);
  
    #endregion
}
