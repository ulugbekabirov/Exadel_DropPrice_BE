namespace BL.Models
{
    public class AdminSearchModel : SpecifiedAmountModel
    {
        public string SearchQuery { get; set; }

        public bool SortByRating { get; set; }

        public bool SortByTicketCount { get; set; }
    }
}
