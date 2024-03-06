

using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using Domain.entities.GamePart.Platform;

namespace Application.ViewModel.UserSide;

public class CatalogViewModel
{
    public List<Game> games {  get; set; }
    public List<Platform> platforms { get; set; }
    public List<Genre> Genres { get; set; }
        
    // sarch 
    public string? Search {  get; set; }
    public int? PlatfromId { get; set; }
    public int? GenreId { get; set; }
    public int MaxPrice { get; set; }
    public int MinPrice { get; set; } = 0;

}
