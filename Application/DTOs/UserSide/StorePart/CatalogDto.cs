

namespace Application.DTOs.UserSide.StorePart
{
    public class CatalogDto
    {
        #region Game
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public decimal Price { get; set; }
        public float Rating { get; set; }
        public List<string> Screenshots { get; set; }
        #endregion

      
    }
}
