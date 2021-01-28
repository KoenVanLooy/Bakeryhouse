using BakeryHouse.Helper;
using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.ViewModels
{
    public class AdminViewModel
    {
        public List<Order> Orders { get; set; }

        public PaginatedList<Order> paginaList { get; set; }

        public string CurrentSort { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }

        public string LeverDateSortParm { get; set; }
        public string CurrentFilter { get; set; }


    } 
}
