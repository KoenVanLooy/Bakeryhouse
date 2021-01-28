using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.ViewModels
{
    public class OrderViewModel
    {
        public Order order { get; set; }

        public Klant Klant { get; set; }

        public string Today { get; set; }

        public string RadioField { get; set; }

        public string FaultMessage { get; set; }
        public List<Afhaalpunt> afhaalpunten { get; set; }
        public string leverdatum { get; set; }
        public Afhaalpunt Afhaalpunt { get; set; }

        public List<Item> Items { get; set; }

        public Decimal Total { get; set; }
        public double Totaal { get; set; }
    }
}
