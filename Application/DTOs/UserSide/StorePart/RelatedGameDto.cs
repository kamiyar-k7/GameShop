using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserSide.StorePart
{
    public record RelatedGameDto
    {
        #region Game
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public string Trailer { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<string> Screenshots { get; set; }
        #endregion

        #region Genre 
        public string GenreId { get; set; }
        public string GenreName { get; set; }
        
        #endregion
    }
}
