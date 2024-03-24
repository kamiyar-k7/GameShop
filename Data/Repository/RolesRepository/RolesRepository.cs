
using Data.ShopDbcontext;
using Domain.entities.UserPart.Roles;
using Domain.IRepository.RoleRepositoryInterface;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository.RolesRepository;


public class RolesRepository  : IRoleRepository
{
    #region Ctor
    private readonly GameShopDbContext _DbContext;
    public RolesRepository(GameShopDbContext gameShopDb )
    {
            _DbContext = gameShopDb;
    }
    #endregion


    public async Task<List<Role>> GetUserRolesById(int Id)
    {
        var roles = await   _DbContext.SelectedRole.Where(x=> x.UserId == Id).Select(x=> x.Role).ToListAsync();
       return roles;
    } 
}

