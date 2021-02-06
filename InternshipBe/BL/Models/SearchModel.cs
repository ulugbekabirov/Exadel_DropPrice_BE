using System;

namespace BL.Models
{
    public class SearchModel : SortModel
    {
        public string SearchQuery { get; set; }

        public string[] Tags { get; set; } = Array.Empty<string>();
    }
}
