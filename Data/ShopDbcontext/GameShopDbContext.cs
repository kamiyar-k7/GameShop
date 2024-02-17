using Domain.entities.Roles;
using Domain.entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ShopDbcontext
{
    public class GameShopDbContext : DbContext
    {
        public GameShopDbContext(DbContextOptions<GameShopDbContext> options) : base(options)
        {

        }

        #region Dbsets
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserSelectedRole> SelectedRole { get; set; }
        #endregion
    }
}
