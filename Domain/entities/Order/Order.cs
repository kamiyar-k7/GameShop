
using Domain.entities.Cart;

namespace Domain.entities.Order;

public class Order
{
   public int Id { get; set; }
    public int CartId { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime DeliveryDate { get; set; }
    public OrderStatus Status { get; set; }
  

    public Carts Cart { get; set; }
}
