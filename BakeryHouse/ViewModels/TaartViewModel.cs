﻿using BakeryHouse.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.ViewModels
{
    public class TaartViewModel
    {
        public List<Product> producten { get; set; }

        public List<Productregel> productregels { get; set; }
    }
}
