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

        public AccountController( IAccountService accountService , ICartService cartService )
        {
           _accountService = accountService;
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
                var user = await _accountService.AddToDataBase(model, cancellation);
                if (user)
                {
                    return RedirectToAction("SignIn", "Account");
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
               
                    TempData["ErrorMessage"] = "Email Or Password Are Incorecct!";
                      return RedirectToAction(nameof(SignIn));



            }
            TempData["ErrorMessage"] = "Fill Fields Properly";
            return RedirectToAction(nameof(SignIn));
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




       

    }
}
