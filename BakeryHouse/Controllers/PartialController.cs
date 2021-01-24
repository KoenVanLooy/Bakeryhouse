using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BakeryHouse.Data;
using BakeryHouse.Models;
using BakeryHouse.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeryHouse.Controllers
{
    public class PartialController : Controller
    {
        private BakeryHouseContext _context;

        //https://stackoverflow.com/questions/48994929/trying-to-use-a-viewmodel-on-a-partial-view
        public PartialController(BakeryHouseContext context)
        {
            _context = context;
        }
        protected virtual async Task<TModel> CreateModel<TModel>() where TModel : LoginPartialViewModel, new()
        {
            TModel model = new TModel();
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);

            // Set common properties
            model.klant = klant;

            return model;
        }
    }
}
