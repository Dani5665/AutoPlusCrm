using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1000)]
        [Comment("Purpose of the visit")]
        public string? VisitPurpose { get; set; } = string.Empty;

        [MaxLength(1000)]
        [Comment("Any information that came from the client. It can be about our products, competitors, his impressions...")]
        public string? CustomerComments { get; set; } = string.Empty;

        [MaxLength(1000)]
        [Comment("Actions taken from the visitor so that the client starts using our services and products ")]
        public string? TakenActions { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Comment("The date when the visit happened")]
        public DateTime DateOfVisit { get; set; }

        //[Required]
        //public string VisitGradeId { get; set; } = string.Empty;

        //public VisitGrade VisitGrade { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(VisitCreator))]
        public string VisitCreatorId { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [Comment("The name of the user that created the task")]
        public ApplicationUser VisitCreator { get; set; } = null!;

        [Required]
        [Comment("Id of the client")]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public Client Client { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(RetailerStore))]
        public int RetailerStoreId { get; set; }

        [Required]
        [Comment("The name of the supplier store")]
        public RetailerStores RetailerStore { get; set; } = null!;

        [Comment("The city of the visited location")]
        public string? City { get; set; } = string.Empty;

        [Comment("The region of the visited location")]
        public string? Region { get; set; } = string.Empty;

        [Comment("Client type id")]
        [ForeignKey(nameof(ClientType))]
        public int? ClientTypeId { get; set; }

        [Comment("The type of the visited location")]
        public ClientType ClientType { get; set; } = null!;


    }
}
