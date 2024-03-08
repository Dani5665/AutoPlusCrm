using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.Data.Models
{
    public class RetailerStores
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; } = string.Empty;

		public ICollection<Visit> Visits { get; set; } = null!;

		public ICollection<Client> Clients { get; set; } = null!;
    }
}
