using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.entities.GamePart.GemSelectedGenre;

namespace Domain.entities.Store.GemSelectedGenre;

public class GemeSelectedGenre
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int GenreId { get; set; }
    


    #region Rels
    public Game.Game Game { get; set; }
    public Genre Genre { get; set; }
    #endregion
}
