using Domain.entities.GamePart.GemSelectedGenre;
using Domain.entities.GamePart.Paltform;
using Domain.entities.Store.Game;
using Domain.entities.Store.GemSelectedGenre;
using Domain.entities.UserPart.Roles;
using Domain.entities.UserPart.User;
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
        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserSelectedRole> SelectedRole { get; set; }
        #endregion

        #region Game
        public DbSet<Game> games { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Platform> platforms { get; set; }
        public DbSet<GemeSelectedGenre> SelectedGenres { get; set; }
        public DbSet<GameSelectedPlatform> selectedPlatforms { get; set; }
        #endregion
        #endregion
    }
}
