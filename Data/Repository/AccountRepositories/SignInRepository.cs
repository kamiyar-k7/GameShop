
using Application.DTOs.UserSide.Account;
using Data.ShopDbcontext;
using Domain.entities.UserPart.User;
using Domain.IRepository.AccountRepositorieInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.AccountRepositories;

public class SignInRepository : ISignInRepository
{
	#region Ctor
	private readonly GameShopDbContext _dbContext;
    public SignInRepository(GameShopDbContext gameShopDb)
    {
            _dbContext = gameShopDb;
    }
    #endregion

    #region General 
    public async Task<User?> FindUser(User user)
    {
        var us = await _dbContext.Users.Where(x => x.Email == user.Email && x.Password == user.Password).Select(x => new User(){

            Id = x.Id,
            Email  = x.Email,
            Created = x.Created,
            IsAdmin = x.IsAdmin,
            PhoneNumber = x.PhoneNumber,
            SuperAdmin = x.SuperAdmin,
            UserCart = x.UserCart,
            UserName = x.UserName,
            UserSelectedRoles = x.UserSelectedRoles,

        }).FirstOrDefaultAsync();

        return us;


    
     }
    #endregion
}
