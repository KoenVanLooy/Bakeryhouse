using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string Soort { get; set; }
        public string Allergeen { get; set; }
        public int Voorraad { get; set; }
        public double Prijs { get; set; }

        public ICollection<Productregel> Productregels { get; set; }
    }
}
