

using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using Domain.entities.GamePart.Platform;

namespace Application.ViewModel.UserSide;

public class ProductViewModel
{
    public Game Games { get; set; }   
    public List<Platform> Platforms { get; set; }
    public List<Genre> Genres  { get; set; }
    public int Quantity { get; set; }
    public int Platformid { get; set; }
    #region related
    public List<Game> RelatedGames { get; set; }
    #endregion
}
