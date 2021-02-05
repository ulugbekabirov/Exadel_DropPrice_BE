using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class SearchModel : SortModel
    {
        public string SearchQuery { get; set; }

        public string[] Tags { get; set; } = Array.Empty<string>();
    }
}
