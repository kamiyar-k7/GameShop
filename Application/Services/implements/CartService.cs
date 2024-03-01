using Application.DTOs.UserSide.Account;
using Application.DTOs.UserSide.StorePart;
using Application.Services.Interfaces;
using Domain.entities.Cart;
using Domain.entities.GamePart.Game;
using Domain.entities.UserPart.User;
using Domain.IRepository.CartRepositoryInterface;
using Domain.IRepository.UserRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.implements;

public class CartService : ICartService
{
    #region Ctor
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;

    public CartService(ICartRepository cartRepository, IUserRepository userRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
    }
    #endregion

    #region General
    public async Task<List<CartDto>> GetUserCart(int id)
    {
        var carts = await _cartRepository.GetListOfUserCart(id);
        if (carts != null)
        {
            List<CartDto> model = new List<CartDto>();

            foreach (var cart in carts)
            {
                CartDto childmodel = new CartDto()
                {




                };
                model.Add(childmodel);
            }
            return model;
        }
        return null;
    }


    //public int AddOrderToTheShopCart(int userid)
    //{
    //    #region Initial Order

    //    Carts carts = new Carts()
    //    {
    //        UserId = userid,

    //    };
    //    _cartRepository.AddUserCartToCarts(carts);

    //    #endregion

    //    return carts.CartId;
    //}

    //public void AddProductToOrderDetail(ProductDto model)
    //{
    //    #region Fill Order Detail

    //    CartDeatails orderDetails = new CartDeatails()
    //    {

    //        //OrderID = OrderID,
    //        //ProductID = ProductID,
    //        //Price = Price,
    //        //Count = count,
    //        //ColorId = colorId,
    //        //SizeId = sizeId
    //    };

    //    #endregion

    //    _cartRepository.AddToCart(orderDetails);
    //}


    public async Task AddToCart(ProductDto model, int userid)
    {
        if (model != null)
        {
            var user = await _userRepository.GetUserByIdAsync(userid);
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
            
                var cid = user.cart.First().CartId;

                CartDeatails cartdetails = new CartDeatails()
                {
                    CartId = cid,
                    GameId = model.Id,
                    Price = model.Price,
                    Quantity = 2,
                    Platform = "yy"
                           
                };
                await _cartRepository.AddToCart(cartdetails);
            

        }




    }

    #endregion
}
