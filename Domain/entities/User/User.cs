using Domain.entities.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.User
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? UserAvatar { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }
    }
}
