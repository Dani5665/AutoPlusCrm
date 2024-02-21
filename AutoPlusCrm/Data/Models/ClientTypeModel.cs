using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.Data.Models
{
    public class ClientTypeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;
    }
}
