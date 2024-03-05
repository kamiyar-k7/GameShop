using Data.ShopDbcontext;
using Domain.entities.GamePart.Game;
using Domain.IRepository.ProductRepositoryInterface;

namespace Data.Repository.ProductRepository;

public class ProductRepository : IProductRepository
{
    #region Ctor
    private readonly GameShopDbContext _gameShopDbContext;
    public ProductRepository(GameShopDbContext gameShopDbContext)
    {
        _gameShopDbContext = gameShopDbContext;

    }

    public Task<Game> GetGameById(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Game>> GetGames()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region General


    #endregion

}
