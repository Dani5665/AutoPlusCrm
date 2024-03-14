using AutoPlusCrm.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
	public class FutureTaskViewModel
	{
		public FutureTaskViewModel(
			int id,
			string? taskDescription,
			DateTime dateAndTime,
			string city,
			string region,
			bool iscompleted,
			string applicationUserId,
			ApplicationUser applicationUser,
			int clientId,
			Client client,
			int retailerStoreId,
			RetailerStores retailerStore)
		{
			Id = id;
			TaskDescription = taskDescription;
			DateAndTime = dateAndTime;
			City = city;
			Region = region;
			Iscompleted = iscompleted;
			ApplicationUserId = applicationUserId;
			ClientId = clientId;
			Client = client;
			ApplicationUser = applicationUser;
			RetailerStoreId = retailerStoreId;
			RetailerStore = retailerStore;
        }

		public int Id { get; set; }

		[MaxLength(200)]
		public string? TaskDescription { get; set; }

		public int ClientId { get; set; }

		public Client Client { get; set; } = null!;

		public DateTime DateAndTime { get; set; }

		public string City { get; set; } = string.Empty;

		public string Region { get; set; } = string.Empty;

		public string ApplicationUserId { get; set; } = string.Empty;

		public ApplicationUser ApplicationUser { get; set; } = null!;

		public bool Iscompleted { get; set; }

        public int RetailerStoreId { get; set; }

        public RetailerStores RetailerStore { get; set; } = null!;
    }
}
