using AutoPlusCrm.Data.Models;

namespace AutoPlusCrm.ViewModels
{
    public class VisitTableViewModel
    {
        public int Id { get; set; }

        public DateTime DateOfVisit { get; set; }

        public string VisitCreatorId { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public Client Client { get; set; } = null!;

        public int RetailerStoreId { get; set; }

        public string? City { get; set; } = string.Empty;

        public string? Region { get; set; } = string.Empty;

        public int? ClientTypeId { get; set; }
    }
}
