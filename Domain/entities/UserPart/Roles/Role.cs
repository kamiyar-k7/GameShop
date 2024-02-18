using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities.UserPart.Roles
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleTitle { get; set; }

        public string RoleUniqueName { get; set; }

        public bool IsDelete { get; set; }

        #region Rols
        public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }
        #endregion

    }
}
