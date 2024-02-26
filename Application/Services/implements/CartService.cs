using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.entities.UserPart.User;
using Domain.IRepository.CartRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        #region Generel

        #region ListOfCart
        public async Task<List<CartDto>> ListOfCart()
        {
            var cart = await _cartrepository.GetListOfCart();
            if (cart != null)
            {
                List<CartDto> model = new List<CartDto>();

                foreach (var carts in cart)
                {
                    CartDto cartDto = new CartDto()
                    {
                        Id = carts.Id,
                        GameName = carts.GameName,
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
        #endregion

        #region AddToCart


        public async Task AddToCAart(string userphone, ProductDto model)
        {
            var game = await _cartrepository.CheckGame(model.Id);
            if (game != null)
            {
               
              var url = game.Screenshots.FirstOrDefault()?.AvararUrl;
                    Cart cart = new Cart()
                    {
                        GameId = game.Id,
                        GameName = game.Name,
                        Price = game.Price,
                        Quantity = model.Quantity,
                        ScreenShot = url , 
                        Platform = " dd"
                        
                        
                    };
                    
                    await _cartrepository.AddToCart(userphone,cart);
                    await _cartrepository.SaveChanges();

                
            }






        }

        #endregion

        #region Delete cart
        public async Task DeleteCart(string userphone , int productid)
        {
            await _cartrepository.DeleteCart(userphone , productid);
            await _cartrepository.SaveChanges();
        }

        #endregion
        #endregion

    }
}
