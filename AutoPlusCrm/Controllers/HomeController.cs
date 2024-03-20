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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorPage(int? statusCode = null)
		{
			if (statusCode.HasValue && statusCode.Value == 404)
			{
				return View("Error404");
			}
            else if (statusCode.HasValue && statusCode.Value == 500)
            {
                return View("Error500");
            }
			// Handle other error codes if needed
			return View();
		}
	}
}
