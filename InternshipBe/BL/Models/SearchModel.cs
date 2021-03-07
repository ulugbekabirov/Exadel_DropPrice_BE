using System;

namespace BL.Models
{
    public class SearchModel : SortModel
    {
        public string SearchQuery { get; set; }

        public int[] Tags { get; set; } = Array.Empty<int>();
    }
}
