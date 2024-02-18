using Domain.entities.Store.GemSelectedGenre;
using System.Collections.ObjectModel;
namespace Domain.entities.GamePart.GemSelectedGenre;

public class Genre
{
    public int Id { get; set; }
    public string GenreName { get; set; }
    public string GenreUniqueName { get; set; }

    #region Rels
  
    public Collection<GemeSelectedGenre> gemeSelectedGenres { get; set; }

    #endregion



    //public string Adventure { get; set; }
    //public string RolePlaying { get; set; }
    //public string Strategy { get; set; }
    //public string Simulation { get; set; }
    //public string Puzzle { get; set; }
    //public string Racing { get; set; }
    //public string Sports { get; set; }
    //public string Fighting { get; set; }
    //public string Shooter { get; set; }
    //public string Platformer { get; set; }
    //public string Survival { get; set; }
    //public string Horror { get; set; }
    //public string Sandbox { get; set; }
    //public string Stealth { get; set; }
    //public string OpenWorld { get; set; }
    //public string MMORPG { get; set; }
    //public string Roguelike { get; set; }
    //public string TowerDefense { get; set; }
    //public string Educational { get; set; }
}
