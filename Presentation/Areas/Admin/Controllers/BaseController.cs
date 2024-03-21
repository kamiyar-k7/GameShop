using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

[Authorize]
[Area("Admin")]
public class BaseController : Controller
{

}
