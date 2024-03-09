
using Data.ShopDbcontext;
using Domain.entities.WebSite;
using Domain.IRepository.HomeRepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.HomeRepsitory;

public class HomeRepository : IHomeRepository
{
    #region Ctor
    private readonly GameShopDbContext _dbContext;
    public HomeRepository(GameShopDbContext gameShopDbContext)
    {
        _dbContext = gameShopDbContext;
    }
    #endregion

    public async Task<AboutUs?> AboutUs()
    {
        return await _dbContext.AboutUs.FirstOrDefaultAsync();
    }

    public async Task ContactUs(ContactUs contactUs)
    {
        await _dbContext.ContactUs.AddAsync(contactUs);
        await _dbContext.SaveChangesAsync();
    }

  
}

