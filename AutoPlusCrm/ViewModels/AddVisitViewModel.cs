using AutoPlusCrm.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPlusCrm.ViewModels
{
    public class AddVisitViewModel
    {
        public int Id { get; set; }

        public string? VisitPurpose { get; set; } = string.Empty;

        public string? CustomerComments { get; set; } = string.Empty;

        public string? TakenActions { get; set; } = string.Empty;

        public string DateOfVisit { get; set; } = string.Empty;

        public string VisitCreatorId { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public int RetailerStoreId { get; set; }

        public string? City { get; set; } = string.Empty;

        public string? Region { get; set; } = string.Empty;

        public int? ClientTypeId { get; set; }
    }
}
