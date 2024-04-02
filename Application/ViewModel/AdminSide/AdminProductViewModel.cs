
using Domain.entities.GamePart.Game;

namespace Application.ViewModel.AdminSide;

public record AdminProductViewModel : AdminBaseViewModel
{
    public GameViewModelAdmin Game { get; set; }
    public List<PlatformViewModelAdmin> Platforms { get; set; }
    public List<GenreViewModelAdmin> Genres { get; set; }
    public List<CommentsViewModelAdmin> Comments { get; set; }

    public List<ListOfGamesAdmin> ListGames { get; set; }

}


public record ListOfGamesAdmin
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public GameStatus Status { get; set; }
    public int Quantity { get; set; }
    public List<string> ScreenShots { get; set; }
}

public record GameViewModelAdmin
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Company { get; set; }
    public decimal Price { get; set; }
    public float Rating { get; set; }
    public string Trailer { get; set; }
    public string SystemRequirements { get; set; }
    public List<string> ScreenShots { get; set; }
    public string Status { get; set; }
}



public record PlatformViewModelAdmin
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PlatformUniqueName { get; set; }
}
public record GenreViewModelAdmin
{
    public int Id { get; set; }
    public string GenreName { get; set; }
    public string GenreUniqueName { get; set; }
}


public record CommentsViewModelAdmin
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserAvatar { get; set; }
    public int GameId { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public decimal Ratings { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;


}
