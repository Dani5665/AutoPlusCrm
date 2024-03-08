using AutoPlusCrm.Data;
using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AutoPlusCrm.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminPanelController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public AdminPanelController(ApplicationDbContext context, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            data = context;
            userManager = _userManager;
			roleManager = _roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users
                .AsNoTracking()
                .Select(u => new UsersTableDetailsViewModel(
                    u.Id,
                    u.Email,
                    u.UserFullName,
                    u.UserStore))
                .ToListAsync();

            return View(users);
        }

		[HttpGet]
		public async Task<IActionResult> AddUser()
		{
			PopulateUserRolesList();
			PopulateRetailerStoresList();

			var model = new EditUserViewModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddUser(EditUserViewModel model, string selectedRole, string selectedStore)
		{
			PopulateUserRolesList();
			PopulateRetailerStoresList();

			string email = model.UserEmail; ;
			string password = model.UserPassword;
            string fullName = model.UserFullName;
            string store = selectedStore;
			string role = selectedRole;

			if (await userManager.FindByNameAsync(email) == null)
				{
					var user = new ApplicationUser();
					user.UserName = email;
					user.Email = email;
                    user.UserStore = store;
                    user.UserFullName = fullName;

					await userManager.CreateAsync(user, password);

					if (role != null) 
					{
						await userManager.AddToRoleAsync(user, role);
					}
				}
			

			return RedirectToAction("Index", "AdminPanel");
		}

		//[HttpGet]
		//      public async Task<IActionResult> EditUser(int id)
		//      {

		//      }

		//      [HttpPost]
		//      public async Task<IActionResult> EditUser()
		//      {

		//      }

		public void PopulateUserRolesList()
		{
			var roles = roleManager.Roles.ToList();
			ViewBag.UserRoles = new SelectList(roles, "Name", "Name");
		}

		public void PopulateRetailerStoresList()
		{
			var retailerStores = data.RetailerStores.ToList();
			ViewBag.RetailerStores = new SelectList(retailerStores, "Name", "Name");
		}
	}
}
