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
        public int Id { get; set; }

        public string[] Roles { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
