using Domain.entities.Store.GemGenreDto;
using System.Collections.ObjectModel;
namespace Domain.entities.GamePart.GemGenreDto;

public class Genre
{
    public int Id { get; set; }
    public string GenreName { get; set; }
    public string GenreUniqueName { get; set; }

    #region Rels
  
    public Collection<GameSelectedGenre> gameSelectedGenre { get; set; }

    #endregion


}
