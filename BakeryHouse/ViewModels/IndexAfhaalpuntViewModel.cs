using BakeryHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryHouse.ViewModels
{
    public class IndexAfhaalpuntViewModel:LoginPartialViewModel
    {
       public List<Afhaalpunt> Afhaalpunten{ get; set; }
    }
}
