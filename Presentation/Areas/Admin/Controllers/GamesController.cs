using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class GamesController : BaseController
{
    #region Ctor

    public GamesController()
    {
            
    }
    #endregion
    public IActionResult ListOfGames()
    {
        return View();
    }
}
