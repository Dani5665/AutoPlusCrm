using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class FutureTask
    {
        [Key]
        public int Id { get; set; }

        [Comment("Description of the task")]
        [MaxLength(200)]
        public string? TaskDescription { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public Client Client { get; set; } = null!;

        [Required]
        [Comment("The date when the visit will be made")]
        public DateTime DateAndTime { get; set; }

        [Required]
        [MaxLength(20)]
        [Comment("The city in which the client store is located")]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Comment("The region in which the client store is located")]
        public string Region { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = string.Empty;

        [Required]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public int RetailerStoreId { get; set; }

        public RetailerStores RetailerStore { get; set; } = null!;

        [Required]
        public bool Iscompleted { get; set; }
    }
}
