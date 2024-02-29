using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.entities.UserPart.User;
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
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
                _cartRepository = cartRepository;
        }
        #endregion

        #region General
        public async Task<List<CartDto>> GetUserCart(int id)
        {
            var carts = await _cartRepository.GetListOfUserCart(id);
            if(carts != null)
            {
                List<CartDto> model = new List<CartDto>();

                foreach(var cart in carts)
                {
                    CartDto childmodel = new CartDto()
                    {
                        Id = cart.Id,
                        UserId = cart.Id,
                        GameId = cart.GameId,
                        GameName = cart.GameName,
                        Platform = cart.Platform,
                        Price = cart.Price,
                        Quantity = cart.Quantity,
                        Screenshot = cart.Screenshot

                        
                    };
                    model.Add(childmodel);
                }
                return model;
            }
            return null;
        }

        public async Task AddToCart(ProductDto model , int userid)
        {

            if(model != null)
            {
                Cart cart = new Cart()
                {
                    GameId = model.Id,
                    GameName  = model.Name,
                    Price = 40,
                    Quantity = model.Quantity,
                    Screenshot = "ddd",
                    UserId = userid
                    ,Platform = "dsdds",
                    
                };

                await _cartRepository.AddToCart(cart);
              
            }
           
        }
        
        #endregion
    }
}
