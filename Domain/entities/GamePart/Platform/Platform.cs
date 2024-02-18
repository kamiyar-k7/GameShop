
namespace Domain.entities.GamePart.Paltform;

public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PlatformUniqueJName { get; set; }

    #region rels
    public ICollection<GameSelectedPlatform> gameSelectedPlatforms { get; set; }
    #endregion

}
