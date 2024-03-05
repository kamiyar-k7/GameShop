

using Application.DTOs.UserSide.Account;
using Application.Services.Interfaces;
using Domain.entities.Cart;
using Domain.entities.GamePart.Game;
using Domain.IRepository.CartRepositoryInterface;

namespace Application.Services.implements;

public class CheckOutService : ICheckOutService
{

	#region Ctor
	private readonly ICartRepository _cartRepository;
    public CheckOutService(ICartRepository cartRepository)
    {
            _cartRepository = cartRepository;
    }
    #endregion

    #region Genereal
    public async Task<List<CheckOutDto>> ShowcCheckOut(int userid)
    {
        if(userid != null)
        {
            var cart = await _cartRepository.GetCartsAsync(userid);
            if(cart != null)
            {
                List<CheckOutDto> model = new List<CheckOutDto>();

                foreach (var item in cart)
                {
                    CheckOutDto childmodel = new CheckOutDto()
                    {
                        UserId =userid,
                        CartId = item.CartId,
                        GameId = item.GameId,
                        GameName = item.Game.Name,
                        Platform = item.Platform,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        
                    };
                    model.Add(childmodel);
                }
                return model;
            }
            return null;
            
        }
        return null;
    }
    #endregion
}
