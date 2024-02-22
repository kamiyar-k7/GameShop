using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserSide.StorePart
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public string Trailer { get; set; }
        public string SystemRequirements { get; set; }
        public List<string> Screenshots { get; set; }

    }
}
