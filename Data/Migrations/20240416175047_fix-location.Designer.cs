﻿// <auto-generated />
using System;
using Data.ShopDbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(GameShopDbContext))]
    [Migration("20240416175047_fix-location")]
    partial class fixlocation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.entities.Cart.CartDeatails", b =>
                {
                    b.Property<int>("CartDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartDetailsId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartDetailsId");

                    b.HasIndex("CartId");

                    b.HasIndex("GameId");

                    b.ToTable("CartDeatails");
                });

            modelBuilder.Entity("Domain.entities.Cart.Carts", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("RegestredDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TrackingPostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Domain.entities.Cart.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PostCode")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique()
                        .HasFilter("[CartId] IS NOT NULL");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.entities.Comments.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<decimal>("Ratings")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Game.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GamesStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantitiy")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("SystemRequirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Game.Screenshot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvararUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Screenshot");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Genre.GemeSelectedGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("GenreId");

                    b.ToTable("SelectedGenres");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Genre.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Platform.GameSelectedPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlatformId");

                    b.ToTable("SelectedPlatforms");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Platform.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Domain.entities.UserPart.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleUniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.entities.UserPart.Roles.UserSelectedRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("SelectedRole");
                });

            modelBuilder.Entity("Domain.entities.UserPart.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SuperAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("UserAvatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.entities.WebSite.AboutUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("Domain.entities.WebSite.ContactUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactUs");
                });

            modelBuilder.Entity("Domain.entities.Cart.CartDeatails", b =>
                {
                    b.HasOne("Domain.entities.Cart.Carts", "Cart")
                        .WithMany("CartDeatails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.entities.GamePart.Game.Game", "Game")
                        .WithMany("CartDeatails")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Domain.entities.Cart.Carts", b =>
                {
                    b.HasOne("Domain.entities.UserPart.User.User", "User")
                        .WithMany("cart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.entities.Cart.Location", b =>
                {
                    b.HasOne("Domain.entities.Cart.Carts", "Cart")
                        .WithOne("Location")
                        .HasForeignKey("Domain.entities.Cart.Location", "CartId");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Domain.entities.Comments.Comments", b =>
                {
                    b.HasOne("Domain.entities.GamePart.Game.Game", "Game")
                        .WithMany("Comments")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.entities.UserPart.User.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Game.Screenshot", b =>
                {
                    b.HasOne("Domain.entities.GamePart.Game.Game", "Game")
                        .WithMany("Screenshots")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Genre.GemeSelectedGenre", b =>
                {
                    b.HasOne("Domain.entities.GamePart.Game.Game", "Game")
                        .WithMany("gemeSelectedGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.entities.GamePart.Genre.Genre", "Genre")
                        .WithMany("gemeSelectedGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Platform.GameSelectedPlatform", b =>
                {
                    b.HasOne("Domain.entities.GamePart.Game.Game", "Game")
                        .WithMany("gameSelectedPlatforms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.entities.GamePart.Platform.Platform", "Platform")
                        .WithMany("gameSelectedPlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Domain.entities.UserPart.Roles.UserSelectedRole", b =>
                {
                    b.HasOne("Domain.entities.UserPart.Roles.Role", "Role")
                        .WithMany("UserSelectedRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.entities.UserPart.User.User", "User")
                        .WithMany("UserSelectedRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.entities.Cart.Carts", b =>
                {
                    b.Navigation("CartDeatails");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Game.Game", b =>
                {
                    b.Navigation("CartDeatails");

                    b.Navigation("Comments");

                    b.Navigation("Screenshots");

                    b.Navigation("gameSelectedPlatforms");

                    b.Navigation("gemeSelectedGenres");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Genre.Genre", b =>
                {
                    b.Navigation("gemeSelectedGenres");
                });

            modelBuilder.Entity("Domain.entities.GamePart.Platform.Platform", b =>
                {
                    b.Navigation("gameSelectedPlatforms");
                });

            modelBuilder.Entity("Domain.entities.UserPart.Roles.Role", b =>
                {
                    b.Navigation("UserSelectedRoles");
                });

            modelBuilder.Entity("Domain.entities.UserPart.User.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("UserSelectedRoles");

                    b.Navigation("cart");
                });
#pragma warning restore 612, 618
        }
    }
}
