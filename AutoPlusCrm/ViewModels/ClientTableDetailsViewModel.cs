using System.ComponentModel.DataAnnotations;

namespace AutoPlusCrm.ViewModels
{
    public class ClientTableDetailsViewModel
    {
        public ClientTableDetailsViewModel(
            int id,
            string name,
            string city)
        {
            Id = id;
            Name = name;
            City = city;
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
    }
}
