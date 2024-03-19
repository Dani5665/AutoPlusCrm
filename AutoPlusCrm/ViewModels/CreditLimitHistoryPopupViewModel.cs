namespace AutoPlusCrm.ViewModels
{
    public class CreditLimitHistoryPopupViewModel
    {
        public CreditLimitHistoryPopupViewModel(int id, int value, DateTime date)
        {
            Id = id;
            Value = value;
            Date = date;
        }

        public int Id { get; set; }

        public int Value { get; set; }

        public DateTime Date { get; set; }
    }
}
