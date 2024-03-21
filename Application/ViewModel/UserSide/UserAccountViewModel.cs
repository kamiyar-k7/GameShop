

using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.UserSide;

public class UserAccountViewModel
{
    public UserDeatailViewModel Deatail { get; set; }
    public List<UserCommentsViewModel> Comments { get; set; }


     
}

public record UserDeatailViewModel
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
    public IFormFile? AvatarForm {  get; set; }
    public DateTime DateTime { get; set; }
}

public record UserOrdersViewModel
{

}
public record UserCommentsViewModel
{
 
    public string Title { get; set; }
    public string Comment { get; set; }
    public decimal Ratings { get; set; }
    public DateTime CreatedAt { get; set; } 
    public int GameId { get; set; }
    public string GameName { get; set; }
}
