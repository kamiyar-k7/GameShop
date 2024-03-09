

using Application.ViewModel.UserSide;

namespace Application.DTOs.UserSide.Home;

public class HomeDto
{
	#region Game
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public float Rating { get; set; }
	public string Trailer { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<string> Screenshots { get; set; }
	#endregion

	 public string search {  get; set; }
}

