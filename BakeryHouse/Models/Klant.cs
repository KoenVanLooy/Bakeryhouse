using BakeryHouse.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryHouse.Models
{
    public class Klant
    {

        public int KlantId { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }

        public ICollection<Order> Orders { get; set; }

        public string UserId { get; set; }

        public CustomUser CustomUser { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"KlantId: {KlantId}");
            stringBuilder.Append($"Voornaam: {Voornaam}");
            stringBuilder.Append($"Naam: {Naam}");

            return stringBuilder.ToString();
        }
    }
}
