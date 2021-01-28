using BakeryHouse.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="Max Lengte van de field is: {1}")]
        public string Naam{ get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        [Range(0, 1000,ErrorMessage ="Gelieve binnen de min {1} en max {2} te blijven")]
        public decimal Prijs { get; set; }
        
        public string Image { get; set; }
        [Required]
        [NotNullOrWhiteSpaceValidator]
        public string Type { get; set; }
        public ICollection<Orderlijn> Orderlijnen { get; set; }
        public List<Productregel> Productregels { get; set; }
    }
}
