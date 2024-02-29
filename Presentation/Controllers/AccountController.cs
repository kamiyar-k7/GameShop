using Application.DTOs.UserSide.Account;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs.UserSide.StorePart;


namespace Presentation.Controllers
{
    public class AccountController : Controller
    {

        #region Ctor
        private readonly ISignUpService _signpService;
        private readonly ISignInService _signInService;
        private readonly ICartService _cartService;
        public AccountController(ISignUpService SignUpservice, ISignInService signInService , ICartService cartService)
        {
            _signpService = SignUpservice;
            _signInService = signInService;
            _cartService = cartService;
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
        public async Task<IActionResult> SignIn()
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
                var cart = await _cartService.GetUserCart(id);
                return View(cart);
             
            }

            return View();
        }
        #endregion

        #region Add Cart
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(ProductDto model)
        
        {
            
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userid, out int id))
                {
                     await _cartService.AddToCart(model,id );
                }
                return RedirectToAction("Product" , "Store" , );
                 
          
        }
        #endregion

        #region Delete Cart'
        public async Task<IActionResult> DeleteCart()
        {

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
    }
}
