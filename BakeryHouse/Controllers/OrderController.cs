using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using BakeryHouse.Areas.Identity.Data;
using BakeryHouse.Data;
using BakeryHouse.Helper;
using BakeryHouse.Models;
using BakeryHouse.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakeryHouse.Controllers
{
    public class OrderController : Controller
    {
        private readonly BakeryHouseContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        public OrderController(BakeryHouseContext context, UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        //Get
        public IActionResult Index()
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            OrderViewModel viewModel = new OrderViewModel
            {
                order = new Order(),
                Today = today
            };
           
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                List<Orderlijn> orderlijnen = new List<Orderlijn>();
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                Order order = viewModel.order;
                order.AfhaalpuntId = 1;
                string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);

                order.KlantId = klant.KlantId;
                _context.Add(order);
                await _context.SaveChangesAsync();

                Order orderprodregel = await _context.Orders
                    .Include(o => o.Orderlijnen)
                    .ThenInclude(ol => ol.Product)
                    .Include(o => o.Afhaalpunt)
                    .SingleOrDefaultAsync(ol => ol.OrderId == viewModel.order.OrderId);
                foreach (Item item in cart)
                {
                    Orderlijn orderlijn = new Orderlijn();
                    orderlijn.Aantal = item.Aantal;
                    orderlijn.OrderId = viewModel.order.OrderId;
                    orderlijn.Order = orderprodregel;
                    orderlijn.Productid = item.product.ProductId;

                    orderprodregel.Orderlijnen.Add(orderlijn);
                }
                
                await _context.SaveChangesAsync();
                viewModel.leverdatum = orderprodregel.LeverDatum.ToString("dd-MM-yyyy");
                viewModel.Afhaalpunt = orderprodregel.Afhaalpunt;
            }
            
           return View(viewModel);
        }
    }
}
