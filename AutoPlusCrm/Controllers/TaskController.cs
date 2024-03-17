using AutoPlusCrm.Data.Models;
using AutoPlusCrm.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

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

		public async Task<IActionResult> Index(string[] selectedStores)
        {
			await PopulateRetailerStoreFilterListAsync();

            if (User.IsInRole("Admin") || User.IsInRole("Manager")) 
			{
				if (selectedStores != null && selectedStores.Length > 0)
				{
                    var tasks = await data.Tasks.Where(t => selectedStores.Contains(t.RetailerStore.Name))
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

			var dateParsed = DateTime.Parse(model.DateAndTime);

			var task = new FutureTask();
			task.TaskDescription = model.TaskDescription;
			task.DateAndTime = dateParsed;
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
			var task = await data.Tasks
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.Id == taskId);

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
				var clients = await data.Clients
					.AsNoTracking()
					.Where(c => c.RetailerStoresId == user.UserStoreId).ToListAsync();
				ViewBag.Clients = new SelectList(clients, "Id", "Name");
			}
			else
			{
				// Handle scenario where user is not found
				ViewBag.Clients = new SelectList(new List<Client>(), "Id", "Name");
			}
		}

        public async Task PopulateRetailerStoreFilterListAsync()
        {
			var retailerStores = await data.RetailerStores
				.AsNoTracking()
				.ToListAsync();

			ViewBag.StoreFilters = new SelectList(retailerStores, "Name", "Name");
        }

    }
}
