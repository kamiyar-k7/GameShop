using Domain.entities.GamePart.Paltform;
using Domain.entities.Store.GemSelectedGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.Store.Game
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public string Trailer { get; set; }
        public string SystemRequirements { get; set; }
        public List<string> Screenshots { get; set; }



        #region Rels
        public ICollection<GemSelectedGenre.GemeSelectedGenre> gemeSelectedGenres { get; set; }
        public ICollection<GameSelectedPlatform> gameSelectedPlatforms { get; set; }
        #endregion

    }
}
