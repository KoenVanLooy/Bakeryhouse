﻿using BakeryHouse.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.ViewModels
{
    public class EditProductViewModel
    {
       public Product Product { get; set; }
       public IEnumerable<SelectListItem> Ingredientenlijst { get; set; }
       public IEnumerable<int> GeselecteerdeIngredienten { get; set; }
    }
}
