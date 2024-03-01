﻿using Domain.entities.Cart;
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
    public DbSet<Carts> Cart { get; set; }
    public DbSet<CartDeatails> CartDeatails { get; set; }
    #endregion

    #region Game
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<GemeSelectedGenre> SelectedGenres { get; set; }
    public DbSet<GameSelectedPlatform> SelectedPlatforms { get; set; }
    #endregion

    #endregion


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;


        base.OnModelCreating(modelBuilder);
    }


}
