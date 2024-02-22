using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.Data.Models
{
    public class VisitGradeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Comment("A grade of the visit (Positive/Neutral/Negative)")]
        public string Grade { get; set; } = string.Empty;
    }
}
