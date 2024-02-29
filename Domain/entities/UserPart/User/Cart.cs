using Domain.entities.GamePart.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.UserPart.User;

public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    public string GameName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Screenshot { get; set; }

    #region rels
    public User User { get; set; }
    public List<Game> Game { get; set; }
    #endregion
}
