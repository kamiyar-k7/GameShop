﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class HomeController : BaseController
{
	public IActionResult Index()
	{
		return View();
	}
}
