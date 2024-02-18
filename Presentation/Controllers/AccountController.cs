using Application.DTOs.AdminSide.Account;
using Application.Services.implements;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {

        #region Ctor
        private readonly iSignUpService _signpService;
		public AccountController(iSignUpService SignUpservice) 
        {
            _signpService = SignUpservice;
        }

        #endregion

        #region SignUp
        [HttpGet]
		public async Task<IActionResult> SignUp()
		{

			return View();
		}
		[HttpPost , ValidateAntiForgeryToken]
		public async Task<IActionResult> SignUp(SignUpDto model , CancellationToken cancellation)
		{
            if(ModelState.IsValid)
            {
             var user =   await  _signpService.AddToDataBase(model, cancellation);
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





		public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index" , "Home");
        }
        public IActionResult DeleteAccount()
        {
            return View();
        }
    }
}
