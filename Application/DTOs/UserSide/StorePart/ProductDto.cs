
namespace Application.DTOs.UserSide.StorePart;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public string? Company { get; set; }
    public decimal Price { get; set; }
    public float? Rating { get; set; }
    public int Quantity { get; set; }
    public string? Trailer { get; set; }
    public string Platform { get; set; } = "kk";
    public string? SystemRequirements { get; set; }
    public List<string>Screenshots { get; set; }

}