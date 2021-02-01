using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class LocationModel : SpecifiedAmountModel
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
