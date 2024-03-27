using AutoPlusCrm.Contracts;
using AutoPlusCrm.Data;
using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoPlusCrm.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> userManager;

        public ClientService(ApplicationDbContext context, UserManager<ApplicationUser> _userManager)
        {
            data = context;
            userManager = _userManager;
        }

        public async Task<IEnumerable<ClientTableDetailsViewModel>> GetAllTableViewAsync()
        {
            return await data.Clients
                .AsNoTracking()
                .Include(c => c.RetailerStores)
                .Select(c => new ClientTableDetailsViewModel(
                    c.Id,
                    c.Name,
                    c.City,
                    c.RetailerStoresId,
                    c.RetailerStores))
                .ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var client = await data.Clients
                .Include(c => c.CreditLimits)
                .Include(c => c.MainDiscounts)
                .Include(c => c.ClientStore)
                .Include(c => c.RetailerStores)
                .Include(c => c.Visits)
                    .ThenInclude(v => v.VisitCreator)
                .FirstOrDefaultAsync(c => c.Id == id);

            return client;
        }

        public async Task<ClientFormViewModel> GetFormViewModelByIdAsync(int id)
        {
            var customer = await data.Clients
                .Include(c => c.CreditLimit)
                .Include(c => c.MainDiscount)
                .FirstOrDefaultAsync(c => c.Id == id);

            return new ClientFormViewModel()
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
                MainDiscount = customer.MainDiscount.DiscountPercentage,
                CreditLimit = customer.CreditLimit.Value,
                DelayedPaymentPeriod = customer.DelayedPaymentPeriod ?? 0,
                ClientDescription = customer.ClientDescription ?? string.Empty,
            };
        }
    }
}
