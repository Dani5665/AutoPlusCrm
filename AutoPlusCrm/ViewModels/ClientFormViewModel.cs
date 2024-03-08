using AutoPlusCrm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
    public class ClientFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? City { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public string? Bulstat { get; set; } = string.Empty;

        public string? AccountablePerson { get; set; } = string.Empty;

        public string? PersonToContact { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress, ErrorMessage ="Email is not in a valid format")]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;

        public string? CatalogueUser { get; set; } = string.Empty;

        public string? CataloguePassword { get; set; } = string.Empty;

        public string? SkypeUser { get; set; } = string.Empty;

        public string? WebsiteUrl { get; set; } = string.Empty;

        public int? MainDiscount { get; set; } = 0;

        public int? CreditLimit { get; set; } = 0;

        public int? DelayedPaymentPeriod { get; set; } = 0;

        public string? ClientDescription { get; set; } = string.Empty;

        public int? RetailerStoreId { get; set; }
    }
}
