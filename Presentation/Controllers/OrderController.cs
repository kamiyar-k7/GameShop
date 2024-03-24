using Application.Services.Interfaces;
using Application.ViewModel.UserSide;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Controllers;

[Authorize]
public class OrderController : Controller
{
    #region Ctor
    private readonly ICartService _cartService;
    public OrderController(ICartService cartService)
    {
           _cartService = cartService;
    }
    #endregion

    #region My Cart
     
    public async Task<IActionResult> MyCart()
    {
        var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (int.TryParse(userid, out int id))
        {
            var cart = await _cartService.ShowListOfCart(id);
            return View(cart);

        }

        return View();
    }
    #endregion

    #region Add Cart
     
    [HttpPost]
    public async Task<IActionResult> AddToCart(ProductViewModel model)
    {

        var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (int.TryParse(userid, out int id))
        {

            await _cartService.AddToCart(model, id);
        }

        return RedirectToAction("Product", "Store", new { id = model.Game.Id });



    }
    #endregion

    #region Delete Cart
     

    public async Task<IActionResult> DeleteCart(int Id)
    {

        var del = await _cartService.DeleteCart(Id);
        if (del)
        {
            return RedirectToAction(nameof(MyCart));
        }
        TempData["error"] = "error";
        return RedirectToAction(nameof(MyCart)); ;
    }
    #endregion

    #region CheckOut
     
    [HttpGet]
    public async Task<IActionResult> CheckOut()
    {
        var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (int.TryParse(userid, out int id))
        {
            var model = await _cartService.CheckOut(id);
            return View(model);
        }
        return NotFound();
      
    }
     
    [HttpPost]
    public async Task<IActionResult> CheckOut(CheckOutViewModel viewModel)
    {

        return View();
    }
    #endregion
}
