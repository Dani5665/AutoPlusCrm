using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.Data.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Comment("The name of the client that will be visited")]
        public string ClientName { get; set; } = string.Empty;

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
        [MaxLength(30)]
        [Comment("The name of the user that created the task")]
        public string TaskCreator { get; set; } = string.Empty;
    }
}
