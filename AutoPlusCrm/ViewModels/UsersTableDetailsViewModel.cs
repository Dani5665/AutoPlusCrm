namespace AutoPlusCrm.ViewModels
{
    public class UsersTableDetailsViewModel
    {
        public UsersTableDetailsViewModel(
            string id,
            string userFullName,
            string userEmail,
            string userStore)
        {
            Id = id;
            UserEmail = userEmail;
            UserFullName = userFullName;
            UserStore = userStore;
        }
        public string Id { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string UserFullName { get; set; } = string.Empty;
        public string UserStore { get; set; } = string.Empty;
    }
}
