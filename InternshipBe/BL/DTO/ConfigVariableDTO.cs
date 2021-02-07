using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ConfigVariableDTO
    {
        public int ConfigId { get; set; }

        public string ConfigValue { get; set; }

        public string ConfigDescription { get; set; }

        public string ConfigName { get; set; }
    }
}
