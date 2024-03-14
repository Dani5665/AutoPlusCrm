using AutoPlusCrm.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
    public class ClientTableDetailsViewModel
    {
        public ClientTableDetailsViewModel(
            int id,
            string name,
            string city,
            int retailerStoreId,
            RetailerStores retailerStore)
        {
            Id = id;
            Name = name;
            City = city;
            RetailerStoreId = retailerStoreId;
            RetailerStore = retailerStore;
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public int RetailerStoreId { get; set; }
        public RetailerStores RetailerStore { get; set; }
    }
}
