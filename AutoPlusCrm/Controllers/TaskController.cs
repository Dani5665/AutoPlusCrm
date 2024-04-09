using AutoPlusCrm.Contracts;
using AutoPlusCrm.Data;
using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoPlusCrm.Controllers
{
	[Authorize]
    public class TaskController : Controller
    {
		private readonly ApplicationDbContext data;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ITaskService taskService;

		public TaskController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ITaskService _taskService)
		{
			data = context;
			_userManager = userManager;
			taskService = _taskService;
		}

		public async Task<IActionResult> Index(string[] selectedStores)
        {
			await PopulateRetailerStoreFilterListAsync();

            if (User.IsInRole("Admin") || User.IsInRole("Manager")) 
			{
				if (selectedStores != null && selectedStores.Length > 0)
				{
					var tasks = (await taskService.ReturnViewForIndexPageAsync())
						.Where(t => selectedStores.Contains(t.RetailerStore.Name))
						.OrderBy(t => t.DateAndTime)
						.ToList();

                    return View(tasks);
                }
				else
				{
					var tasks = await taskService.ReturnViewForIndexPageAsync();

					tasks.OrderByDescending(t => t.DateAndTime);

                    return View(tasks);
                }
				
			}
			else if (User.IsInRole("User"))
			{
				var user = await _userManager.GetUserAsync(User);

				if (user == null)
				{
					return NotFound();
				}

				var tasks = (await taskService.ReturnViewForIndexPageAsync())
					.Where(t => t.ApplicationUserId == user.Id)
					.OrderByDescending(t => t.DateAndTime)
					.ToList();

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
                return RedirectToAction("Error404", "Home", 404);
            }

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var task = new FutureTask()
			{
				TaskDescription = model.TaskDescription,
				DateAndTime = DateTime.Parse(model.DateAndTime),
				City = model.City,
				Region = model.Region,
				Iscompleted = false,
				ApplicationUserId = user.Id,
				RetailerStoreId = user.UserStoreId,
				ClientId = selectedClient
			};

			await data.Tasks.AddAsync(task);
			await data.SaveChangesAsync();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> CompleteTask(int taskId)
		{
			var task = await taskService.GetTaskByIdAsync(taskId);

			if (task == null)
			{
                return RedirectToAction("Error404", "Home", 404);
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
