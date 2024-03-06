using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Application.ViewModel.UserSide;
using Domain.entities.Cart;
using Domain.IRepository.AccountRepositorieInterfaces;
using Domain.IRepository.CartRepositoryInterface;
using Domain.IRepository.GameRepository;
using Domain.IRepository.PlatformRepositoryInterface;


namespace Application.Services.implements;

public class CartService : ICartService
{
    #region Ctor
    private readonly ICartRepository _cartRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IGameRepository _gameRepository;
    private readonly IPlatformRepository _platformRepository;
    public CartService(ICartRepository cartRepository, 
        IAccountRepository accountRepository,
        IGameRepository gameRepository, 
        IPlatformRepository platformRepository)
    {
        _cartRepository = cartRepository;
        _accountRepository = accountRepository;
        _gameRepository = gameRepository;
        _platformRepository = platformRepository;
    }
    #endregion

    #region General
    public async Task<List<CartDto>> ShowListOfCart(int userid)
    {
        var cart = await _cartRepository.GetCartsAsync(userid);
        if (cart != null)
        {
            List<CartDto> model = new List<CartDto>();

            foreach (var item in cart)
            {
                CartDto childmodel = new CartDto()
                {
                    Id = item.CartDetailsId,
                    GameId = item.GameId,
                    GameName = item.Game.Name,
                   Platform = item.Platform,
                    Quantity = item.Quantity,
                    Price = item.Game.Price,
                    Screenshot = item.Game.Screenshots.First().AvararUrl,
                    UserId = userid
                };
                model.Add(childmodel);
            }
            return model;
        }
        return null;
    }


    public async Task AddToCart(ProductViewModel model, int userid)
    {
        if (model != null)
        {

            var user = await _accountRepository.GetUserByIdAsync(userid);
            if (user == null)
            {
                throw new Exception();
            }

            if (user.cart == null || user.cart.Count == 0)
            {
                Carts newcart = new Carts()
                {
                    UserId = userid,
                    Price = 0
                };

                await _cartRepository.AddUserCartToCarts(newcart);


            }

            var cartid = user.cart.First().CartId;
            var game = await _gameRepository.GetGameById(model.Games.Id);
            var platform = await _platformRepository.GetSelectedPlatform(model.Platformid);
            var exist =  _cartRepository.IsGameExistInCart(cartid, game.Id , platform.Name);
            
            if (exist != null)
            {
                exist.Quantity += model.Quantity;
                await _cartRepository.AddOneMoreToCart(exist);
            }
            else
            {
                CartDeatails cartdetails = new CartDeatails()
                {
                    CartId = cartid,
                    GameId = model.Games.Id,
                    Price = game.Price,
                    Quantity = model.Quantity,
                    Platform = platform.PlatformUniqueName




                };
                await _cartRepository.AddToCart(cartdetails);
            }

        }
    }

 
    public async Task<bool> DeleteCart(int id)
    {
       var cart = await _cartRepository.FindCartById(id);
        if(cart == null)
        {
      
        return false;
        }
        _cartRepository.DeleteCart(cart);
        await _cartRepository.SaveChanges();
        return true;

    }
    #endregion
}
