using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Max Lengte van de field is: {1}")]
        public string Soort { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Max Lengte van de field is: {1}")]
        public string Allergeen { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Gelieve binnen de min {1} en max {2} te blijven")]
        public int Voorraad { get; set; }
        [Required]
        [Range(0, 999.99, ErrorMessage = "Gelieve binnen de min {1} en max {2} te blijven")]
        public double Prijs { get; set; }

        public ICollection<Productregel> Productregels { get; set; }
    }
}
