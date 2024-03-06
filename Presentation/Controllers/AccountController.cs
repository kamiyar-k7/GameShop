using Application.DTOs.UserSide.Account;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs.UserSide.StorePart;
using Application.ViewModel.UserSide;


namespace Presentation.Controllers
{
    public class AccountController : Controller
    {

        #region Ctor
        private readonly IAccountService _accountService;
        private readonly ICartService _cartService;
        private readonly ICheckOutService _checkOutService;
        public AccountController( IAccountService accountService , ICartService cartService , ICheckOutService checkOutService)
        {
           _accountService = accountService;
            _cartService = cartService;
            _checkOutService = checkOutService;
        }

        #endregion



        #region SignUp
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpDto model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountService.AddToDataBase(model, cancellation);
                if (user)
                {
                    return RedirectToAction("SignIn", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "This Phone or Email Already Exist";
                }


            }
            else
            {
                TempData["ErrorMessage"] = "Fill Fields Properly";
            }
            return View();
        }
        #endregion

        #region SignIn
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountService.FindUser(model);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {

                        new (ClaimTypes.NameIdentifier ,user.Id.ToString()),
                         new (ClaimTypes.Email ,user.Email),
                          new (ClaimTypes.Name , user.UserName),
                         new (ClaimTypes.MobilePhone ,user.PhoneNumber)
                    };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimIdentity);

                    var authProps = new AuthenticationProperties();
                    // authProps.IsPersistent = model.Remmemberme;

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Email Or Password Are Incorecct!";
                }

                return View();

            }
            TempData["ErrorMessage"] = "Fill Fields Properly";
            return View();
        }

        #endregion

        #region LogOut
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region DeleteAccount

        public IActionResult DeleteAccount()
        {
            return View();
        }
        #endregion

        #region ForgotPassword
        public IActionResult ForgotPassword()
        {
            return View();
        }
        #endregion

        #region My Account(Index)
        public IActionResult Index()
        {
            return View();
        }
        #endregion




        #region My Cart
        [Authorize]
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(ProductViewModel model)
        {
            
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userid, out int id))
                {
                
                     await _cartService.AddToCart(model,id );
                }
                return RedirectToAction("Product" , "Store"  , new {id = model.Games.Id});
                 
          

        }
        #endregion

        #region Delete Cart
        [Authorize]
       
        public async Task<IActionResult> DeleteCart(int Id)
        {

          var del =  await _cartService.DeleteCart(Id);
            if (del)
            {
                return RedirectToAction(nameof(MyCart));
            }
            TempData["error"] = "error";
            return RedirectToAction(nameof(MyCart)); ;
        }
        #endregion

        #region CheckOut
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userid, out int id))
            {
                var model =  await _checkOutService.ShowcCheckOut(id);
                return View(model);
            }
            return NotFound();
          
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CheckOut(CheckOutDto model)
        {

            return View();
        }
        #endregion

    }
}
