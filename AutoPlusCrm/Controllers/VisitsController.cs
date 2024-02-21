using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoPlusCrm.Controllers
{
    [Authorize]
    public class VisitsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
