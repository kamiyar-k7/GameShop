
namespace Application.DTOs.UserSide.Account;

public class CheckOutDto
{
    // 
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Postcode { get; set;}
    public string? Note { get; set; }


    // cart    
    public int CartId { get; set; }
    public int GameId { get; set; }
    public string GameName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Screenshot { get; set; }
    public string Platform { get; set; }
}
