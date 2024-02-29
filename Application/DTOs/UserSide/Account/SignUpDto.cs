using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserSide.Account
{
    public class SignUpDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password And Repeat Paswword Are Not Same!!")]
        [MinLength(8)]
        public string RepeatPassword { get; set; }
        public string PhoneNumber { get; set; }

    }
}
