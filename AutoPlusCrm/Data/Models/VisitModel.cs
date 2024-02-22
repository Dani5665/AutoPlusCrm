using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class VisitModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        [Comment("Purpose of the visit")]
        public string VisitPurpose { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        [Comment("Any information that came from the client. It can be about our products, competitors, his impressions...")]
        public string CustomerComments { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        [Comment("Actions taken from the visitor so that the client starts using our services and products ")]
        public string TakenActions { get; set; } = string.Empty;

        [Required]
        [Comment("The date when the visit happened")]
        public DateTime DateOfVisit { get; set; }

        [Required]
        public int VisitGradelId { get; set; }

        [ForeignKey(nameof(VisitGradelId))]
        public VisitGradeModel VisitGrade { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [Comment("The name of the user that created the task")]
        public string VisitCreator { get; set; } = string.Empty;
    }
}
