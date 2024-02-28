using Application.DTOs.AdminSide.Account;
using Application.DTOs.UserSide.Account;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.DTOs.UserSide.StorePart;
using Microsoft.AspNetCore.Authorization;


namespace Presentation.Controllers
{
    public class AccountController : Controller
    {

        #region Ctor
        private readonly ISignUpService _signpService;
        private readonly ISignInService _signInService;
        private readonly ICartService _cartService;
        public AccountController(ISignUpService SignUpservice, ISignInService signInService, ICartService cartService)
        {
            _signpService = SignUpservice;
            _signInService = signInService;
            _cartService = cartService;
        }

        #endregion

        #region SignUp
        [HttpGet]
        public  IActionResult SignUp()
        {

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpDto model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var user = await _signpService.AddToDataBase(model, cancellation);
                if (user)
                {
                    return RedirectToAction("Index", "Home");
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
        public  IActionResult SignIn()
        {

            return View();
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInService.FindUser(model);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {

                        new (ClaimTypes.NameIdentifier ,user.UserName.ToString()),
                         new (ClaimTypes.Email ,user.Email),
                         
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

        #region My Account(Index)
        public IActionResult Index()
        {
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

        #region My Cart
        [Authorize]
        public async Task<IActionResult> MyCart()
        {
            var cart = await _cartService.ListOfCart();
            if (cart != null)
            {
                return View(cart);
            }

            return View();
        }
        #endregion

        #region Add to cart
        [HttpPost, ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddToCart(ProductDto model)
        {
            string userphone = User.FindFirstValue(ClaimTypes.MobilePhone);


            if (ModelState.IsValid)
            {
               
                await _cartService.AddToCAart(userphone, model);
                return RedirectToAction("Product", "Store", new { id = model.Id });
            }
            return null;

        }
        #endregion

        #region Delete Product From Cart
       
        public async Task<IActionResult>  DeleteCart(int Id) 
        {
            string userphone = User.FindFirstValue(ClaimTypes.MobilePhone);
            await _cartService.DeleteCart(userphone, Id);
            return RedirectToAction(nameof(MyCart));
           
        }

        #endregion

        #region CheckOut
        [Authorize]
        public async Task<IActionResult> CheckOut()
        {
            return View();
        }
        #endregion
    }
}
