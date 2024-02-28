using Microsoft.AspNetCore.Mvc;

namespace AutoPlusCrm.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
