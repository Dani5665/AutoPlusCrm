using AutoPlusCrm.Data.Models;
using AutoPlusCrm.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPlusCrm.Controllers
{
    public class TaskController : Controller
    {
		private readonly ApplicationDbContext data;
		private readonly UserManager<ApplicationUser> _userManager;

		public TaskController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			data = context;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Manager")) 
			{
				var tasks = await data.Tasks
					.AsNoTracking()
                    .Include(t => t.ApplicationUser)
                    .Include(t => t.Client)
					.Include(t => t.RetailerStore)
                    .Select(t => new FutureTaskViewModel(
						t.Id,
						t.TaskDescription,
						t.DateAndTime,
						t.City,
						t.Region,
						t.Iscompleted,
						t.ApplicationUserId,
						t.ApplicationUser,
						t.ClientId,
						t.Client,
						t.RetailerStoreId,
						t.RetailerStore))
                    .ToListAsync();

				return View(tasks);
			}
			else if (User.IsInRole("User"))
			{
                var tasks = await data.Tasks
                    .AsNoTracking()
                    .Include(t => t.ApplicationUser)
                    .Include(t => t.Client)
                    .Include(t => t.RetailerStore)
                    .Select(t => new FutureTaskViewModel(
                        t.Id,
                        t.TaskDescription,
                        t.DateAndTime,
                        t.City,
                        t.Region,
                        t.Iscompleted,
                        t.ApplicationUserId,
                        t.ApplicationUser,
                        t.ClientId,
                        t.Client,
                        t.RetailerStoreId,
                        t.RetailerStore))
                    .ToListAsync();

                return View(tasks);
			}
			else
			{
				return View();
			}

        }

		[HttpGet]
		public async Task<IActionResult> AddTask()
		{
			await PopulateClientsListAsync();

			var model = new AddFutureTaskViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddTask(AddFutureTaskViewModel model, int selectedClient)
		{
			await PopulateClientsListAsync();

			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var task = new FutureTask();
			task.TaskDescription = model.TaskDescription;
			task.DateAndTime = model.DateAndTime;
			task.City = model.City;
			task.Region = model.Region;
			task.Iscompleted = false;
			task.ApplicationUserId = user.Id;
			task.RetailerStoreId = user.UserStoreId;
			task.ClientId = selectedClient;

			await data.Tasks.AddAsync(task);
			await data.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> CompleteTask(int taskId)
		{
			var task = await data.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

			if (task == null)
			{
				return BadRequest();
			}

			task.Iscompleted = true;

			await data.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		//Populates field where user has to choose a client but only shows the clients with the same Retailerstore 
		public async Task PopulateClientsListAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user != null)
			{
				var clients = await data.Clients.Where(c => c.RetailerStoresId == user.UserStoreId).ToListAsync();
				ViewBag.Clients = new SelectList(clients, "Id", "Name");
			}
			else
			{
				// Handle scenario where user is not found
				ViewBag.Clients = new SelectList(new List<Client>(), "Id", "Name");
			}
		}

	}
}
