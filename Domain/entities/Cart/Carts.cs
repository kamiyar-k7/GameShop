using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.Cart;

public class Carts
{
    [Key]
    public int CartId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public decimal Price { get; set; }

    #region rels
    public  User User { get; set; }
    public List<CartDeatails> CartDeatails { get; set; }
    #endregion
}
