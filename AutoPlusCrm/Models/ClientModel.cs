namespace ApCrm.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientTypeId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Bulstat { get; set; }
        public string AccountablePerson { get; set; }
        public string PersonToContact { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CatalogueUser { get; set; }
        public string CataloguePassword { get; set; }
        public string SkypeUser { get; set; }
        public string WebsiteUrl { get; set; }
        public List<StoreModel> StoreLocations { get; set; }
    }
}
