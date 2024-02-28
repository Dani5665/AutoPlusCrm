using AutoPlusCrm.Data;
using AutoPlusCrm.Data.Migrations;
using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoPlusCrm.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext data;

        public CustomerController(ApplicationDbContext context)
        {
            data = context;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await data.Clients
                .AsNoTracking()
                .Select(c => new ClientTableDetailsViewModel(
                    c.Id,
                    c.Name,
                    c.City))
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
                    ClientDescription = model.ClientDescription
                };

                await data.Clients.AddAsync(entity);
                await data.SaveChangesAsync();

                var mainDiscount = new MainDiscount();

                if (model.MainDiscount != null)
                {
                    //var mainDiscount = new MainDiscount()
                    //{
                    //    DateAndTime = DateTime.Now,
                    //    DiscountPercentage = (int)model.MainDiscount,
                    //    ClientId = entity.Id
                    //};
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
                    //var creditLimit = new CreditLimit()
                    //{
                    //    DateAndTime = DateTime.Now,
                    //    Value = (int)model.CreditLimit,
                    //    ClientId = entity.Id
                    //};

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
                .FindAsync(id);

            if (customer == null)
            {
                return BadRequest();
            }

            var creditLimit = await data.CreditLimits
                .FindAsync(customer.CreditLimitId);

            var discount = await data.MainDiscounts
                .FindAsync(customer.MainDiscountId);

            var model = new ClientFormViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                City = customer.City,
                Address = customer.Address,
                Bulstat = customer.Bulstat,
                AccountablePerson = customer.AccountablePerson,
                PersonToContact = customer.PersonToContact,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                CatalogueUser = customer.CatalogueUser,
                CataloguePassword = customer.CataloguePassword,
                SkypeUser = customer.SkypeUser,
                WebsiteUrl = customer.WebsiteUrl,
                DelayedPaymentPeriod = (int)customer.DelayedPaymentPeriod,
                ClientDescription = customer.ClientDescription
            };

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientFormViewModel model, int id)
        {
            var client = await data.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

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

            var newDiscount = new MainDiscount()
            {
                DateAndTime = DateTime.UtcNow,
                DiscountPercentage = (int)model.MainDiscount,
                ClientId = client.Id
            };
            await data.AddAsync(newDiscount);
            await data.SaveChangesAsync();
            client.MainDiscountId = newDiscount.Id;

            var newCreditLimit = new CreditLimit()
            {
                DateAndTime = DateTime.UtcNow,
                Value = (int)model.CreditLimit,
                ClientId = client.Id
            };
            await data.AddAsync(newCreditLimit);
            await data.SaveChangesAsync();
            client.CreditLimitId = newCreditLimit.Id;


            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDetails(int id)
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

            var model = new ClientInfoViewModel()
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
                ClientDescription = customer.ClientDescription ?? ""
            };

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return View(model);
        }

    }
}
