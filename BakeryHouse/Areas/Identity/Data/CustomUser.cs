﻿using BakeryHouse.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.Areas.Identity.Data
{
    public class CustomUser:IdentityUser
    {
        [PersonalData]
        public Klant Klant { get; set; }
    }
}
