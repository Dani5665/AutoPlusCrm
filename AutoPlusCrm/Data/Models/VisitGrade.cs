using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class VisitGrade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Comment("A grade of the visit (Positive/Neutral/Negative)")]
        public string Grade { get; set; } = string.Empty;

        [Comment("Id of the visit")]
        [ForeignKey(nameof(Visit))]
        public int VisitClassId { get; set; }

        public Visit Visit { get; set; } = null!;
    }
}
