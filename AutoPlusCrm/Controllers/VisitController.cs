using AutoPlusCrm.Contracts;
using AutoPlusCrm.Data;
using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoPlusCrm.Controllers
{
	[Authorize]
    public class VisitController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVisitService visitService;

        public VisitController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IVisitService _visitService)
        {
            data = context;
            _userManager = userManager;
            visitService = _visitService;
        }

		public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager"))
            {
                var visits = await visitService.GetAllTableViewAsync();

				var orderedVisits = visits
					.OrderByDescending(v => v.DateOfVisit)
					.ToList();

				return View(orderedVisits);
            }
            else if (User.IsInRole("User"))
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Error404", "Home", 404);
                }

                var visits = await visitService.GetAllTableViewAsync();

				var sortedVisits = visits
					.Where(v => v.RetailerStore.Id == user.UserStoreId)
					.OrderByDescending(v => v.DateOfVisit)
					.ToList();


				return View(sortedVisits);
            }
            else
            {
                return RedirectToAction("Error404", "Home", 404);
            }
        }

		[HttpGet]
		public async Task<IActionResult> EditVisit(int id)
		{
			var visit = await visitService.GetVisitByIdAsync(id);

			if (visit == null)
			{
				return RedirectToAction("Error404", "Home", 404);
			}

			var model = new EditVisitViewModel()
			{
				VisitPurpose = visit.VisitPurpose,
				CustomerComments = visit.CustomerComments,
				TakenActions = visit.TakenActions,
				City = visit.City,
				Region = visit.Region
			};

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditVisit(EditVisitViewModel model, int id)
		{
			var visit = await visitService.GetVisitByIdAsync(id);

			if (visit == null)
			{
				return RedirectToAction("Error404", "Home", 404);
			}
			else if (!ModelState.IsValid)
			{
				return View(model);
			}

			visit.VisitPurpose = model.VisitPurpose;
			visit.CustomerComments = model.CustomerComments;
			visit.TakenActions = model.TakenActions;
			visit.City = model.City;
			visit.Region = model.Region;

			await data.SaveChangesAsync();

			return RedirectToAction("CustomerDetails", "Customer", new { id = visit.ClientId });
		}

        [HttpPost]
        public async Task<IActionResult> DeleteVisit(int visitId)
        {
            var visit = await visitService.GetVisitByIdAsync(visitId);

			if (visit == null)
            {
				return RedirectToAction("Error404", "Home", 404);
			}

            data.Visits.Remove(visit);
            await data.SaveChangesAsync();

            return RedirectToAction("CustomerDetails", "Customer", new { id = visit.ClientId });
        }
	}
}
