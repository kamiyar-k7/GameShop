using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class StoreController : Controller
    {
        public   IActionResult Index()
        {
            return View();
        }
    }
}
