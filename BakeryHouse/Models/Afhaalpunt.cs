using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Afhaalpunt
    {
        public int AfhaalpuntId { get; set; }
        public string Omschrijving { get; set; }
        public string Adres { get; set; }

        public string Postcode { get; set; }
        
        public string stad { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
