﻿namespace Domain.entities.GamePart.Platform;

public class Platform
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PlatformUniqueName { get; set; }

    #region rels
    public ICollection<GameSelectedPlatform> gameSelectedPlatforms { get; set; }
    #endregion

}
