using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Orderlijn
    {
        public int OrderlijnId { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Aantal { get; set; }
    }
}
