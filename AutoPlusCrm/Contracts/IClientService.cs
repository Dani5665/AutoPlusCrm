using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;

namespace AutoPlusCrm.Contracts
{
    public interface IClientService
    {
        Task<IEnumerable<ClientTableDetailsViewModel>> GetAllTableViewAsync();

        Task<Client> GetClientByIdAsync(int id);

        Task<ClientFormViewModel> GetFormViewModelByIdAsync(int id);
    }
}
