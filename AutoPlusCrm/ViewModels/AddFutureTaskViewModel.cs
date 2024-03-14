using AutoPlusCrm.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
	public class AddFutureTaskViewModel
	{
		public int Id { get; set; }

		[MaxLength(200)]
		public string? TaskDescription { get; set; }

		public int ClientId { get; set; }

		public DateTime DateAndTime { get; set; }

		public string City { get; set; } = string.Empty;

		public string Region { get; set; } = string.Empty;

		public string ApplicationUserId { get; set; } = string.Empty;

		public bool Iscompleted { get; set; }

		public int RetailerStoreId { get; set; }

	}
}
