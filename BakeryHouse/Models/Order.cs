using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int KlantId { get; set; }

        public Klant Klant { get; set; }

        public int AfhaalpuntId { get; set; }
        public Afhaalpunt Afhaalpunt { get; set; }

        [DataType(DataType.Date)]
        public DateTime Orderdatum { get; set; }

        [DataType(DataType.Date)]
        public DateTime LeverDatum { get; set; }
        public ICollection<Orderlijn> Orderlijnen { get; set; }



    }
}
