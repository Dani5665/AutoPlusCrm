using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [MaxLength(50)]
        [Comment("Client type id")]
        public int ClientTypeId { get; set; }

        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Bulstat { get; set; } = string.Empty;

        [MaxLength(50)]
        public string AccountablePerson { get; set; } = string.Empty;

        [MaxLength(50)]
        public string PersonToContact { get; set; } = string.Empty;

        [MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string CatalogueUser { get; set; } = string.Empty;

        [MaxLength(30)]
        public string CataloguePassword { get; set; } = string.Empty;

        [MaxLength(50)]
        public string SkypeUser { get; set; } = string.Empty;

        [MaxLength(50)]
        public string WebsiteUrl { get; set; } = string.Empty;

        public List<StoreModel> StoreLocations { get; set; } = new List<StoreModel>();
    }
}
