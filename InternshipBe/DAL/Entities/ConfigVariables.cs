using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ConfigVariables
    {
        public int Id { get; set; }

        public int RadiusInMeters{ get; set; } = 40000;
    }
}
