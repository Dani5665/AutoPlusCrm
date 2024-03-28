using ApCrm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApCrm.Controllers
{
    [Authorize]
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login");
		}

        public async Task<IActionResult> ErrorPage(int? statusCode = null)
		{
			if (statusCode.HasValue && statusCode.Value == 404)
			{
				return View("Error404");
			}
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
	}
}
