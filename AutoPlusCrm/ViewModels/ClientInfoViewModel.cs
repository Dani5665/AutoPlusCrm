using AutoPlusCrm.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
    public class ClientInfoViewModel
    {
        //Properties for the client
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? City { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public string? Bulstat { get; set; } = string.Empty;

        public string? AccountablePerson { get; set; } = string.Empty;

        public string? PersonToContact { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? CatalogueUser { get; set; } = string.Empty;

        public string? CataloguePassword { get; set; } = string.Empty;

        public string? SkypeUser { get; set; } = string.Empty;

        public string? WebsiteUrl { get; set; } = string.Empty;

        public int? MainDiscount { get; set; } = null!;

        public int? CreditLimit { get; set; } = null!;

        public int DelayedPaymentPeriod { get; set; }

        public string? ClientDescription { get; set; } = string.Empty;

        //Properties for the client store
        public List<ClientStore> ClientStores { get; set; } = new List<ClientStore>();

        //Properties for the visits
        public List<Visit> Visits { get; set; } = new List<Visit>();
    }
}
