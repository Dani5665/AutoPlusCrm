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
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            data = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await data.Clients
                .AsNoTracking()
                .Include(c => c.RetailerStores)
                .Select(c => new ClientTableDetailsViewModel(
                    c.Id,
                    c.Name,
                    c.City,
                    c.RetailerStoresId,
                    c.RetailerStores))
                .ToListAsync();

            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new ClientFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClientFormViewModel model)
        {
			var currentUser = await _userManager.GetUserAsync(User);
            var retailerStore = await data.RetailerStores.FirstOrDefaultAsync(rs => rs.Id == currentUser.UserStoreId);

            if (ModelState.IsValid)
            {
				var entity = new Client()
                {
                    Name = model.Name,
                    City = model.City,
                    Address = model.Address,
                    Bulstat = model.Bulstat,
                    AccountablePerson = model.AccountablePerson,
                    PersonToContact = model.PersonToContact,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    CatalogueUser = model.CatalogueUser,
                    CataloguePassword = model.CataloguePassword,
                    SkypeUser = model.SkypeUser,
                    WebsiteUrl = model.WebsiteUrl,
                    DelayedPaymentPeriod = model.DelayedPaymentPeriod,
                    ClientDescription = model.ClientDescription,
                    RetailerStoresId = retailerStore.Id
                };

                await data.Clients.AddAsync(entity);
                await data.SaveChangesAsync();

                var mainDiscount = new MainDiscount();

                if (model.MainDiscount != null)
                {
                    mainDiscount.DateAndTime = DateTime.Now;
                    mainDiscount.DiscountPercentage = (int)model.MainDiscount;
                    mainDiscount.ClientId = entity.Id;

                    await data.MainDiscounts.AddAsync(mainDiscount);
                }

                var creditLimit = new CreditLimit();

                if (model.CreditLimit != null)
                {
                    creditLimit.DateAndTime = DateTime.Now;
                    creditLimit.Value = (int)model.CreditLimit;
                    creditLimit.ClientId = entity.Id;

                    await data.CreditLimits.AddAsync(creditLimit);
                }

                await data.SaveChangesAsync();

                entity.CreditLimitId = creditLimit.Id;
                entity.MainDiscountId = mainDiscount.Id;

                await data.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await data.Clients
                .Include(c => c.CreditLimits)
                .Include(c => c.MainDiscounts)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return BadRequest();
            }

            var mainDiscount = customer.MainDiscounts.FirstOrDefault(md => md.Id == customer.MainDiscountId);
            var creditLimit = customer.CreditLimits.FirstOrDefault(cl => cl.Id == customer.CreditLimitId);

            var model = new ClientFormViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                City = customer.City ?? "",
                Address = customer.Address ?? "",
                Bulstat = customer.Bulstat ?? "",
                AccountablePerson = customer.AccountablePerson ?? "",
                PersonToContact = customer.PersonToContact ?? "",
                PhoneNumber = customer.PhoneNumber ?? "",
                Email = customer.Email ?? "",
                CatalogueUser = customer.CatalogueUser ?? "",
                CataloguePassword = customer.CataloguePassword ?? "",
                SkypeUser = customer.SkypeUser ?? "",
                WebsiteUrl = customer.WebsiteUrl ?? "",
                MainDiscount = mainDiscount?.DiscountPercentage ?? 0,
                CreditLimit = creditLimit?.Value ?? 0,
                DelayedPaymentPeriod = customer.DelayedPaymentPeriod ?? 0,
                ClientDescription = customer.ClientDescription ?? string.Empty,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientFormViewModel model, int id)
        {
            var client = await data.Clients
                .Include(c => c.CreditLimits)
                .Include(c => c.MainDiscounts)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            var mainDiscount = client.MainDiscounts.FirstOrDefault(md => md.Id == client.MainDiscountId);
            var creditLimit = client.CreditLimits.FirstOrDefault(cl => cl.Id == client.CreditLimitId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            client.Name = model.Name;
            client.Address = model.Address;
            client.City = model.City;
            client.Bulstat = model.Bulstat;
            client.AccountablePerson = model.AccountablePerson;
            client.PersonToContact = model.PersonToContact;
            client.PhoneNumber = model.PhoneNumber;
            client.Email = model.Email;
            client.CatalogueUser = model.CatalogueUser;
            client.CataloguePassword = model.CataloguePassword;
            client.SkypeUser = model.SkypeUser;
            client.WebsiteUrl = model.WebsiteUrl;
            client.DelayedPaymentPeriod = model.DelayedPaymentPeriod;
            client.ClientDescription = model.ClientDescription;

            var newMainDiscount = new MainDiscount();

            if (model.MainDiscount != mainDiscount?.DiscountPercentage && model.MainDiscount != 0)
            {
                newMainDiscount.DateAndTime = DateTime.Now;
                newMainDiscount.DiscountPercentage = (int)model.MainDiscount;
                newMainDiscount.ClientId = client.Id;

                await data.MainDiscounts.AddAsync(newMainDiscount);
            }

            var newCreditLimit = new CreditLimit();

            if (model.CreditLimit != creditLimit?.Value && model.CreditLimit != 0)
            {
                newCreditLimit.DateAndTime = DateTime.Now;
                newCreditLimit.Value = (int)model.CreditLimit;
                newCreditLimit.ClientId = client.Id;

                await data.CreditLimits.AddAsync(newCreditLimit);
            }

            await data.SaveChangesAsync();

            if (model.MainDiscount != mainDiscount?.DiscountPercentage && model.MainDiscount != 0)
            {
                client.MainDiscountId = newMainDiscount.Id;
            }

            if (model.CreditLimit != creditLimit?.Value && model.MainDiscount != 0)
            {
                client.CreditLimitId = newCreditLimit.Id;
            }

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDetails(int id)
        {
            var customer = await data.Clients
                .Include(c => c.CreditLimits)
                .Include(c => c.MainDiscounts)
                .Include(c => c.ClientStore)
                .Include(c => c.RetailerStores)
                .Include(c => c.Visits)
                    .ThenInclude(v => v.VisitCreator)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return BadRequest();
            }

            var mainDiscount = customer.MainDiscounts.FirstOrDefault(md => md.Id == customer.MainDiscountId);
            var creditLimit = customer.CreditLimits.FirstOrDefault(cl => cl.Id == customer.CreditLimitId);
            var stores = customer.ClientStore.Where(cs => cs.ClientId == id).ToList();
            var visits = customer.Visits.Where(v => v.RetailerStoreId == customer.RetailerStoresId).ToList();

            var model = new ClientInfoViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                City = customer.City ?? "-",
                Address = customer.Address ?? "-",
                Bulstat = customer.Bulstat ?? "-",
                AccountablePerson = customer.AccountablePerson ?? "-",
                PersonToContact = customer.PersonToContact ?? "-",
                PhoneNumber = customer.PhoneNumber ?? "-",
                Email = customer.Email ?? "-",
                CatalogueUser = customer.CatalogueUser ?? "-",
                CataloguePassword = customer.CataloguePassword ?? "-",
                SkypeUser = customer.SkypeUser ?? "-",
                WebsiteUrl = customer.WebsiteUrl ?? "-",
                MainDiscount = mainDiscount?.DiscountPercentage ?? 0,
                CreditLimit = creditLimit?.Value ?? 0,
                DelayedPaymentPeriod = customer.DelayedPaymentPeriod ?? 0,
                ClientDescription = customer.ClientDescription ?? "-",
                ClientStores = stores,
                Visits = visits,
                RetailerStore = customer.RetailerStores
            };



            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomerStore(int id)
        {
            var model = new ClientStoreFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerStore(ClientStoreFormViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var entity = new ClientStore()
                {
                    Name = model.Name,
                    Address = model.Address,
                    NumberOfWorkers = model.NumberOfWorkers,
                    NumberOfMechanics = model.NumberOfMechanics,
                    NumberOfVehicles = model.NumberOfVehicles,
                    PersonToContact = model.PersonToContact,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    ClientId = id
                };

                await data.Stores.AddAsync(entity);
                await data.SaveChangesAsync();
            }

            return RedirectToAction("CustomerDetails", "Customer", new {id = id});
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomerStore(int id)
        {
            var customerStore = await data.Stores
                .FindAsync(id);

            if (customerStore == null)
            {
                return NotFound();
            }

            var model = new ClientStoreFormViewModel()
            {
                Id = customerStore.Id,
                Name = customerStore.Name,
                Address = customerStore.Address,
                NumberOfWorkers = customerStore.NumberOfWorkers,
                NumberOfMechanics = customerStore.NumberOfMechanics,
                NumberOfVehicles = customerStore.NumberOfVehicles,
                PersonToContact = customerStore.PersonToContact,
                PhoneNumber = customerStore.PhoneNumber,
                Email = customerStore.Email
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomerStore(ClientStoreFormViewModel model, int id)
        {
            var customerStore = await data.Stores
                .FindAsync(id);

            if(customerStore == null)
            {  
                return View("Error"); 
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            customerStore.Name = model.Name;
            customerStore.Address = model.Address;
            customerStore.NumberOfWorkers = model.NumberOfWorkers;
            customerStore.NumberOfMechanics = model.NumberOfMechanics;
            customerStore.NumberOfVehicles  = model.NumberOfVehicles;
            customerStore.PhoneNumber = model.PhoneNumber;
            customerStore.Email = model.Email;
            customerStore.PersonToContact = model.PersonToContact;

            await data.SaveChangesAsync();
    
            return RedirectToAction("CustomerDetails", "Customer", new { id = customerStore.ClientId });
        }

        [HttpGet]
        public async Task<IActionResult> AddVisit(int id)
        {
			PopulateClientTypesList();
			var model = new AddVisitViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddVisit(AddVisitViewModel model, int id, string selectedType)
        {
            PopulateClientTypesList();

            var user = await _userManager.GetUserAsync(User);
            var userdata = await data.Users
                .Include(ud => ud.UserStore)
                .FirstOrDefaultAsync(ud => ud.Id == user.Id);
                
            var type = selectedType;

			var dateParsed = DateTime.Parse(model.DateOfVisit);

			if (user == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var entity = new Visit()
                {
                    VisitPurpose = model.VisitPurpose,
                    CustomerComments = model.CustomerComments,
                    TakenActions = model.TakenActions,
                    DateOfVisit = dateParsed,
                    VisitCreatorId = user.Id,
                    ClientId = id,
                    RetailerStoreId = userdata.UserStore.Id,
                    City = model.City,
                    Region = model.Region,
                    ClientTypeId = int.Parse(type)
                };

                await data.Visits.AddAsync(entity);
                await data.SaveChangesAsync();
            }

            return RedirectToAction("CustomerDetails", "Customer", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscountHistory(int clientId)
        {
            var discounts = await data.MainDiscounts
                .Where(d => d.ClientId == clientId)
                .OrderBy(d => d.DateAndTime)
                .AsNoTracking()
                .Select(d => new DiscountHistoryPopupViewModel(
                    d.Id,
                    d.DiscountPercentage,
                    d.DateAndTime))
                .ToListAsync();

            return PartialView("_DiscountHistoryPartial", discounts);
        }

        public void PopulateVisitGradeList()
        {
            IEnumerable<SelectListItem> getVisitGrades = data.VisitGrades.Select(vg => new SelectListItem()
            {
                Text = vg.Grade,
                Value = vg.Id.ToString()
            });

            ViewBag.VisitGrades = getVisitGrades;
        }

        public void PopulateClientTypesList()
        {
            var types = data.ClientTypes.ToList();
            ViewBag.ClientTypes = new SelectList(types, "Id", "Type");
        }
    }
}
