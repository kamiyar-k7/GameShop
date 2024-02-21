using Domain.entities.GamePart.GemSelectedGenre;
using Domain.entities.GamePart.Paltform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserSide.StorePart
{
    public class CatalogDto
    {
        #region Game
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public float Price { get; set; }
        public float Rating { get; set; }
        public List<string> Screenshots { get; set; }
        #endregion

      
    }
}
