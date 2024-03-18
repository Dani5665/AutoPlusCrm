namespace AutoPlusCrm.ViewModels
{
    public class DiscountHistoryPopupViewModel
    {
        public DiscountHistoryPopupViewModel(int id, int discountPersentage, DateTime date)
        {
            Id = id;
            DiscountPersentage = discountPersentage;
            Date = date;
        }

        public int Id { get; set; }

        public int DiscountPersentage { get; set; }

        public DateTime Date { get; set; }
    }
}
