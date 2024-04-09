using AutoPlusCrm.Contracts;
using AutoPlusCrm.Data;
using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApCrm.Services
{
	public class VisitService : IVisitService
	{
		private readonly ApplicationDbContext data;
		private readonly UserManager<ApplicationUser> userManager;

		public VisitService(ApplicationDbContext data, UserManager<ApplicationUser> userManager)
		{
			this.data = data;
			this.userManager = userManager;
		}

		public async Task<IEnumerable<VisitTableViewModel>> GetAllTableViewAsync()
		{
			return await data.Visits
				.AsNoTracking ()
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
		}

		public async Task<Visit> GetVisitByIdAsync(int id)
		{
			var visit = await data.Visits.FindAsync(id);

			return visit;
		}
	}
}
