using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class ClientStore
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("The name of the store")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        [Comment("The address of the store")]
        public string? Address { get; set; } = string.Empty;

        [MaxLength(5)]
        [Comment("The number of workers in the store")]
        public int? NumberOfWorkers { get; set; }

        [MaxLength(5)]
        [Comment("The number of mechanics in the store")]
        public int? NumberOfMechanics { get; set; }

        [MaxLength(5)]
        [Comment("The number of vehicles in the store")]
        public int? NumberOfVehicles { get; set; }

        [MaxLength(50)]
        [Comment("The name of the person to contact")]
        public string? PersonToContact { get; set; } = string.Empty;

        [MaxLength(20)]
        [Comment("The phone number of the person to contact")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("The email of the person to contact")]
        public string? Email { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Username for AP catalogue")]
        public string? CatalogueUser { get; set; } = string.Empty;

        [MaxLength(50)]
        [Comment("Password for AP catalogue")]
        public string? CataloguePassword { get; set; } = string.Empty;

        [Comment("List of all the visits made to the store")]
        public IList<Visit> Visits { get; set; } = null!;

        [Comment("Id of the client")]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public Client Client { get; set; } = null!;
    }
}
