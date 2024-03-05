using Domain.entities.Cart;
using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using Domain.entities.GamePart.Platform;
using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.GamePart.Game;

public class Game
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Company { get; set; }
    public decimal Price { get; set; }
    public int Quantitiy { get; set; }
    public float Rating { get; set; }
    public string Trailer { get; set; }
    public string SystemRequirements { get; set; }
    public bool IsDelete { get; set; } = false;




    #region Rels
    public ICollection<Screenshot> Screenshots { get; set; }
    public ICollection<GemeSelectedGenre> gemeSelectedGenres { get; set; }
    public ICollection<GameSelectedPlatform> gameSelectedPlatforms { get; set; }
    public List<CartDeatails> CartDeatails { get; set; }

    #endregion


}

public class Screenshot
{
public int Id { get; set; }
public string AvararUrl { get; set; }
public int GameId { get; set; }
public Game Game { get; set; }

}

