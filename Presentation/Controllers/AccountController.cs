using Application.DTOs.UserSide.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
<<<<<<< HEAD
using Application.ViewModel.UserSide;
using Application.Services.Interfaces.UserSide;
using Application.Helpers;
=======
using Application.DTOs.UserSide.StorePart;
>>>>>>> origin/master
using Microsoft.AspNetCore.Authorization;



namespace Presentation.Controllers;

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
<<<<<<< HEAD
=======

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
>>>>>>> origin/master
            TempData["ErrorMessage"] = "Fill Fields Properly";
        }
<<<<<<< HEAD
        return View();
=======
       
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
>>>>>>> origin/master
    }
    #endregion

    #region SignIn
    [HttpGet]
    public async Task<IActionResult> SignIn(string? ReturnUrl="")
    {
        SignInDto signInDto = new SignInDto();

        if (!string.IsNullOrEmpty(ReturnUrl))
        {
            signInDto.ReturnUrl = ReturnUrl;
        }

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
                 authProps.IsPersistent = model.RememberMe;

              await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
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
        HttpContext.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
    #endregion

    // not finished
    #region DeleteAccount

    public IActionResult DeleteAccount()
    {
        return View();
    }
    #endregion
    // not finished
    #region ForgotPassword
    public IActionResult ForgotPassword()
    {
        return View();
    }
    #endregion

    #region My Account
    [HttpGet]
    [Authorize]
    public async  Task< IActionResult> MyAccount()
    {
        
          var user =   await _accountService.UserViewModel((int)HttpContext.User.GetUserId());

          return View(user);
        

      
    }



    #endregion

    
    #region Edit Account 
    [HttpGet] 
    public async Task<IActionResult> EditAccount(int id)
    {
        var user = await _accountService.UserViewModel(id);
        var details = user.Deatail;
        return View(details);
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAccount(UserDeatailViewModel model)
    {
        var res = await _accountService.UpdateDetails(model);
        if (res)
        {
            return RedirectToAction(nameof(MyAccount));
        }
        return View(model);
    }

    #endregion

}
