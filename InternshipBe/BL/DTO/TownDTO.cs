using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TownDTO
    {
        public int Id { get; set; }

        public string TownName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
