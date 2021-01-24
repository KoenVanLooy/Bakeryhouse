using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Productregel
    {
        public int ProductregelId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
        public int Aantal { get; set; }

    }
}
