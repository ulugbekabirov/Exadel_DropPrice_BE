namespace BL.Models
{
    public class VendorSearchModel : SpecifiedAmountModel
    {
        public string SearchQuery { get; set; }

        public string RatingSort { get; set; }

        public string TicketCountSort { get; set; }
    }
}
