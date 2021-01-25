﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class Tag  
    {
        public int id { get; set; }
        public string Name { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        public Tag()
        {
            Discounts = new List<Discount>();
        }
    }
}
