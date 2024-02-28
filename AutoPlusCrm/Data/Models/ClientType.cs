using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.Data.Models
{
    public class ClientType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Comment("The type of the client (Store, Service...)")]
        public string Type { get; set; } = string.Empty;
    }
}
