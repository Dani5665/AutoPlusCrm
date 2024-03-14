using AutoPlusCrm.Data.Models;

namespace AutoPlusCrm.ViewModels
{
    public class VisitTableViewModel
    {
        public VisitTableViewModel(int id, DateTime dateOfVisit, Client client, RetailerStores retailerStore, string? city, string? region, ClientType clientType)
        {
            Id = id;
            DateOfVisit = dateOfVisit;
            Client = client;
            RetailerStore = retailerStore;
            City = city;
            Region = region;
            ClientType = clientType;
        }

        public int Id { get; set; }

        public DateTime DateOfVisit { get; set; }

        public string VisitCreatorId { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public Client Client { get; set; } = null!;

        public int RetailerStoreId { get; set; }

        public RetailerStores RetailerStore { get; set; } = null!;

        public string? City { get; set; } = string.Empty;

        public string? Region { get; set; } = string.Empty;

        public int? ClientTypeId { get; set; }

        public ClientType ClientType { get; set; } = null!;
    }
}
