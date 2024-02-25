using Application.DTOs.UserSide.Account;
using Application.Services.Interfaces;
using Domain.IRepository.CartRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.implements
{
    public class CartService : ICartService
    {
        #region Ctor 
        private readonly ICartRepository _cartrepository;
        public CartService(ICartRepository cartRepository)
        {
                _cartrepository = cartRepository;
        }

        #endregion

        public async Task<List<CartDto>> ListOfCart()
        {
            var cart = await _cartrepository.GetListOfCart();
            if(cart != null)
            {
                List<CartDto> model = new List<CartDto>();

                foreach (var carts in cart)
                {
                    CartDto cartDto = new CartDto()
                    {
                        Id = carts.Id,
                        GameName    = carts.GameName,
                        Price = carts.Price,
                        Quantity = carts.Quantity,
                        ScreenShot = carts.ScreenShot

                    };
                    model.Add(cartDto);
                }
                return model;
                
            }
            return null;
        }
    }
}
