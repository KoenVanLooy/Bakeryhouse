using BakeryHouse.Helper;
using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.ViewModels
{
    public class IndexProductModel
    {
        List<Product> Products { get; set; }
        public PaginatedList<Product> paginaList { get; set; }

        public string CurrentSort { get; set; }
        public string PrijsSortParm { get; set; }
        public string TypeSortParm { get; set; }

        public string NaamSortParm { get; set; }
        public string CurrentFilter { get; set; }

    }
}
