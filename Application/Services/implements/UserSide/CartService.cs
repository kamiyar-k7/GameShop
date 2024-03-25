using Application.DTOs.UserSide.Account;
using Application.Services.Interfaces.UserSide;
using Application.ViewModel.UserSide;
using Domain.entities.Cart;
using Domain.IRepository.AccountRepositorieInterfaces;
using Domain.IRepository.CartRepositoryInterface;
using Domain.IRepository.GameRepositoryInteface;
using Domain.IRepository.PlatformRepositoryInterface;



namespace Application.Services.implements.UserSide;

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
            var game = await _gameRepository.GetGameById(model.Game.Id);
            var platform = await _platformRepository.GetSelectedPlatform(model.Platformid);
            if (platform != null)
            {
                var exist = _cartRepository.IsGameExistInCart(cartid, game.Id, platform.Name);

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
                        GameId = model.Game.Id,
                        Price = game.Price,
                        Quantity = model.Quantity,
                        Platform = platform.PlatformUniqueName




                    };
                    await _cartRepository.AddToCart(cartdetails);
                }
            }


        }
    }


    public async Task<bool> DeleteCart(int id)
    {
        var cart = await _cartRepository.FindCartById(id);
        if (cart == null)
        {

            return false;
        }
        _cartRepository.DeleteCart(cart);
        await _cartRepository.SaveChanges();
        return true;

    }

    public async Task<CheckOutViewModel> CheckOut(int user)
    {
        var cart = await _cartRepository.GetCartsAsync(user);
        if (cart != null)
        {
            List<OrderDetailsViewModel> model = new List<OrderDetailsViewModel>();
            foreach (var item in cart)
            {
                OrderDetailsViewModel childmodel = new OrderDetailsViewModel()
                {
                    CartDetailsId = item.CartDetailsId,
                    CartId = item.CartId,
                    GameId = item.GameId,
                    GameName = item.Game.Name,
                    Platform = item.Platform,
                    Price = item.Price,
                    Quantity = item.Quantity,
                };
                model.Add(childmodel);
            }
            CheckOutViewModel checkOutViewModel = new CheckOutViewModel()
            {
                OrderDetails = model,
            };
            return checkOutViewModel;
        }
        return null;
    }
    #endregion
}
