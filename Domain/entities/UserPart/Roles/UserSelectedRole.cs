using Domain.entities.UserPart.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.UserPart.Roles
{
    public class UserSelectedRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region rels
        public Role Role { get; set; }
        public User.User User { get; set; }
        #endregion
    }
}
