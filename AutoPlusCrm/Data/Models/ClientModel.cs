using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class ClientModel
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
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        [Comment("Address of client")]
        public string Address { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Firm bulstat")]
        public string Bulstat { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Name of the accountable person (MOL)")]
        public string AccountablePerson { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Person to contact")]
        public string PersonToContact { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Client phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Client email address")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(30)]
        [Comment("Username for the catalogue")]
        public string CatalogueUser { get; set; } = string.Empty;

        [MaxLength(30)]
        [Comment("Password for the catalogue")]
        public string CataloguePassword { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Skype username")]
        public string SkypeUser { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Website url")]
        public string WebsiteUrl { get; set; } = string.Empty;

        [Comment("List of client stores")]
        public List<StoreModel> Stores { get; set; } = new List<StoreModel>();

        [Required]
        public int MainDiscountModelId { get; set; }

        [ForeignKey(nameof(MainDiscountModelId))]
        [Comment("Currently active general discount")]
        public MainDiscountModel MainDiscount { get; set; } = null!;

        [Comment("List of dicount changes")]
        public IList<MainDiscountModel> DiscountHistoryList { get; set; } = new List<MainDiscountModel>();

        [Required]
        public int CreditLimitModelId { get; set; }

        [ForeignKey(nameof(CreditLimitModelId))]
        [Comment("Customer credit limit")]
        public CreditLimitModel CreditLimit { get; set; } = null!;

        [Comment("List of customer credit limit changes")]
        public IList<CreditLimitModel> CreditLimitHistoryList { get; set; } = new List<CreditLimitModel>();

        [Comment("Delayed payment period in days")]
        public int DelayedPaymentPeriod { get; set; }

        [MaxLength(200)]
        [Comment("Short description about the client")]
        public string ClientDescription { get; set; } = string.Empty;
    }
}
