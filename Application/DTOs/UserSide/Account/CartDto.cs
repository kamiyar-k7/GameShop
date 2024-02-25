using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserSide.Account
{
    public class CartDto
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ScreenShot { get; set; }
    }
}
