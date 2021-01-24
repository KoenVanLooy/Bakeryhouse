using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Naam{ get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Prijs { get; set; }

        public string Image { get; set; }
        public string Type { get; set; }
        public ICollection<Orderlijn> Orderlijnen { get; set; }
        public ICollection<Productregel> Productregels { get; set; }
    }
}
