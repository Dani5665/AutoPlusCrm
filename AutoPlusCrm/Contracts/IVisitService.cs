using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;

namespace AutoPlusCrm.Contracts
{
	public interface IVisitService
	{
		Task<IEnumerable<VisitTableViewModel>> GetAllTableViewAsync();

		Task<Visit> GetVisitByIdAsync(int id);
	}
}
