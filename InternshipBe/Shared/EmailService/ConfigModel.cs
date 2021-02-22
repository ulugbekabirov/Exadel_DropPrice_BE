using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public class ConfigModel
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string DataType { get; set; }
    }
}
