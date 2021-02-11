namespace BL.Models
{
    public class AdminSearchModel : SpecifiedAmountModel
    {
        public string SearchQuery { get; set; }

        public bool SortByRatingAsc { get; set; }

        public bool SortByTicketCountAsc { get; set; }
    }
}
