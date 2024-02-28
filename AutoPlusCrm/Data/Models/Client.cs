using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class Client
    {
        [Key]
        [Required]
        [Comment("Primary key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Name of the client")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("City where the client is registered")]
        public string? City { get; set; } = string.Empty;

        [MaxLength(100)]
        [Comment("Address of client")]
        public string? Address { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Firm bulstat")]
        public string? Bulstat { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Name of the accountable person (MOL)")]
        public string? AccountablePerson { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Person to contact")]
        public string? PersonToContact { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Client phone number")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Client email address")]
        public string? Email { get; set; } = string.Empty;

        [MaxLength(30)]
        [Comment("Username for the catalogue")]
        public string? CatalogueUser { get; set; } = string.Empty;

        [MaxLength(30)]
        [Comment("Password for the catalogue")]
        public string? CataloguePassword { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Skype username")]
        public string? SkypeUser { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Website url")]
        public string? WebsiteUrl { get; set; } = string.Empty;

        [Comment("List of client stores")]
        public IList<ClientStore> ClientStore { get; set; } = new List<ClientStore>();

        public int? MainDiscountId { get; set; }

        [Comment("List of dicounts")]
        public IList<MainDiscount> MainDiscounts { get; set; } = new List<MainDiscount>();

        public int? CreditLimitId { get; set; }

        [Comment("Customer credit limit")]
        public IList<CreditLimit> CreditLimits { get; set; } = new List<CreditLimit>();

        [Comment("Delayed payment period in days")]
        public int? DelayedPaymentPeriod { get; set; }

        [MaxLength(200)]
        [Comment("Short description about the client")]
        public string? ClientDescription { get; set; } = string.Empty;


    }
}
