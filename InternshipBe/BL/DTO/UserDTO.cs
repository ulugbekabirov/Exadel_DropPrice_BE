using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string[] Roles { get; set; }

        public double OfficeLatitude { get; set; }

        public double OfficeLongitude { get; set; }
    }
}
