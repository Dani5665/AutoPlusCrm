namespace ApCrm.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfWorkers { get; set; }
        public int NumberOfMechanics { get; set; }
        public int NumberOfVehicles { get; set; }
        public string PersonToContact { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CatalogueUser { get; set; }
        public string CataloguePassword { get; set; }
    }
}
