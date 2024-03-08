using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
	public class EditUserViewModel
	{
		[Required]
		public string Id { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.EmailAddress)]
		public string UserEmail { get; set; } = string.Empty;

		[Required]
		public string UserFullName { get; set; } = string.Empty;

		[Required]
		public string UserStore { get; set; } = string.Empty;

		[DataType(DataType.Password)]
		public string UserPassword { get; set; } = string.Empty;

		[Required]
		public string UserRole { get; set; } = null!;
	}
}
