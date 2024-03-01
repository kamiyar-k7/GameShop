using Data.ShopDbcontext;
using Domain.entities.UserPart.User;
using Domain.IRepository.UserRepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.UserRepository;

public class UserRepository : IUserRepository
{
	#region ctor
	private readonly GameShopDbContext _dbcontext;
    public UserRepository(GameShopDbContext gameShopDbContext)
    {
        _dbcontext = gameShopDbContext;            
    }

    #endregion

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _dbcontext.Users.Include(x => x.cart).FirstOrDefaultAsync(x=> x.Id == id);
    }
    public async Task SaveChanges()
    {
        await _dbcontext.SaveChangesAsync();
    }
}
