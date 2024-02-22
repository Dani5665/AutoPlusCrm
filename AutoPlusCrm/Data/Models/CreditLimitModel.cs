using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.Data.Models
{
    public class CreditLimitModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Number of the credit limit")]
        public int CreditLimit { get; set; }

        [Required]
        [Comment("Date and time when the credit limit was created")]
        public DateTime DateAndTime { get; set; }
    }
}
