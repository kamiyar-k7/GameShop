using Data.ShopDbcontext;
using Domain.entities.UserPart.User;
using Domain.IRepository.AccountRepositorieInterfaces;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.AccountRepositories;

public class AccountRepository : IAccountRepository
{
    #region Ctor

    private readonly GameShopDbContext _dbContext;
    public AccountRepository(GameShopDbContext gameShopDb)
    {
        _dbContext = gameShopDb;
    }
    #endregion

    #region General
 
    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
    public async Task<User?> FindUser(User user)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
    }

    public async Task AddToDataBase(User user, CancellationToken cancellation)
    {
        await _dbContext.AddAsync(user);
    }

    public bool IsExist(string PhoneNumber, string email)
    {
        return _dbContext.Users.Any(x => x.PhoneNumber == PhoneNumber || x.Email == email);

    }
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _dbContext.Users.Include(x => x.cart).FirstOrDefaultAsync(x => x.Id == id);
    }

    #endregion
}



