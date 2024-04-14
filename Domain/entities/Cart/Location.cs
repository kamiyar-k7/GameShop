
namespace Domain.entities.Cart;

public class Location
{

        #region Props

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PosstCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string OrderNote { get; set; }


        #endregion

        public Cart.Carts Cart { get; set; }
    
}
