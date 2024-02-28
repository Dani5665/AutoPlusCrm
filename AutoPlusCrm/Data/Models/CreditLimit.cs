using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class CreditLimit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Number of the credit limit")]
        public int Value { get; set; }

        [Required]
        [Comment("Date and time when the credit limit was created")]
        public DateTime DateAndTime { get; set; }

        [Comment("Id of the client")]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public Client Client { get; set; } = null!;
    }
}
