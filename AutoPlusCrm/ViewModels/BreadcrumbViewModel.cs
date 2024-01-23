namespace ApCrm.ViewModels
{
    public class BreadcrumbViewModel
    {
        public string PageTitle { get; set; }
        public List<BreadcrumbItem> BreadcrumbItems { get; set; }
    }

    public class BreadcrumbItem
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
