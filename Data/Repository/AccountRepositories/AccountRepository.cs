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
       
        return await _dbContext.Users.Include(x => x.cart).Include(x=> x.Comments).Where(x => x.Id == id).Select(x => new User
        {
            Id = x.Id,
            cart = x.cart,
            Comments = x.Comments,
            Created = x.Created,
            Email = x.Email,    
            IsAdmin = x.IsAdmin,
             UserAvatar = x.UserAvatar,
             UserName = x.UserName ,
          
            

        }).FirstOrDefaultAsync();
    }

   public  void  Update(User user)
    {
        _dbContext.Attach(user);

        _dbContext.Entry(user).Property(u => u.UserName).IsModified = true;
       
         _dbContext.Entry(user).Property(u => u.UserAvatar).IsModified = true;
        

    }
    public bool SuperAdmin(int id)
    {
      var user =  _dbContext.Users.Find(id).SuperAdmin;
        return user;
    }
    #endregion


    //------------------------------------
    #region Admin side
    public int CountUsers()
    {
        return _dbContext.Users.Select(x=> x.IsDelete  == false).Count();
    }
    public int CountAdmins()
    {
        var adminRoleId =  _dbContext.Roles.FirstOrDefault(r => r.RoleUniqueName == "Admin")?.Id;
        return _dbContext.SelectedRole.Count(ur => ur.RoleId == adminRoleId);
    }
    #endregion
}



