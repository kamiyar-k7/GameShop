
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
       return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
    }

    #endregion
}
