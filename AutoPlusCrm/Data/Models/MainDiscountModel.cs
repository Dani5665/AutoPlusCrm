using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.Data.Models
{
    public class MainDiscountModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Number of the discount in percentage")]
        public int DiscountPercentage { get; set; }

        [Required]
        [Comment("Date and time when the discount was created")]
        public DateTime DateAndTime { get; set; }
    }
}
