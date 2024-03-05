

using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using Domain.entities.GamePart.Platform;

namespace Application.ViewModel.UserSide;

public class CatalogViewModel
{
    public List<Game> games {  get; set; }
    public List<Platform> platforms { get; set; }
    public List<Genre> Genres { get; set; }
}
