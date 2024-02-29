using Domain.entities.GamePart.Game;
using Domain.entities.GamePart.Genre;
using Domain.entities.GamePart.Platform;
using Domain.entities.UserPart.Roles;
using Domain.entities.UserPart.User;
using Microsoft.EntityFrameworkCore;


namespace Data.ShopDbcontext;

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
