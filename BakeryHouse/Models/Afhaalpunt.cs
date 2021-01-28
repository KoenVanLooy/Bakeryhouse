using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Afhaalpunt
    {

        public int AfhaalpuntId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Max Lengte van de field is: {1}")]
        public string Omschrijving { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Max Lengte van de field is: {1}")]
        public string Adres { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Max Lengte van de field is: {1}")]
        public string Postcode { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Max Lengte van de field is: {1}")]
        public string stad { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
