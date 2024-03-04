using AutoPlusCrm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
    public class ClientStoreFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public int? NumberOfWorkers { get; set; }

        public int? NumberOfMechanics { get; set; }

        public int? NumberOfVehicles { get; set; }

        public string? PersonToContact { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public int ClientId { get; set; }
    }
}
