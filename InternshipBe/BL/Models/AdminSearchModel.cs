namespace BL.Models
{
    public class AdminSearchModel : SpecifiedAmountModel
    {
        public string SearchQuery { get; set; }
        
        public string[] SortBy { get; set; }
    }
}
