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

        public string Today { get; set; }

        public string leverdatum { get; set; }
        public Afhaalpunt Afhaalpunt { get; set; }
    }
}
