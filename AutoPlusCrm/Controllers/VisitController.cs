using AutoPlusCrm.Data.Models;
using AutoPlusCrm.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPlusCrm.ViewModels;

namespace AutoPlusCrm.Controllers
{
    [Authorize]
    public class VisitController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> _userManager;

        public VisitController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            data = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager"))
            {
                var visits = await data.Visits
                    .Include(v => v.Client)
                    .Include(v => v.ClientType)
                    .Include(v => v.RetailerStore)
                    .Select(v => new VisitTableViewModel(
                        v.Id,
                        v.DateOfVisit,
                        v.Client,
                        v.RetailerStore,
                        v.City,
                        v.Region,
                        v.ClientType
                    ))
                    .ToListAsync();

                return View(visits);
            }
            else if (User.IsInRole("User"))
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Error404", "Home", 404);
                }

                var visits = await data.Visits
                    .Where(v => v.RetailerStoreId == user.UserStoreId)
                    .Include(v => v.Client)
                    .Include(v => v.ClientType)
                    .Include(v => v.RetailerStore)
                    .Select(v => new VisitTableViewModel(
                        v.Id,
                        v.DateOfVisit,
                        v.Client,
                        v.RetailerStore,
                        v.City,
                        v.Region,
                        v.ClientType
                    ))
                    .ToListAsync();

                return View(visits);
            }
            else
            {
                return RedirectToAction("Error404", "Home", 404);
            }
        }
    }
}
