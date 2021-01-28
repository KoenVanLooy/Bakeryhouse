using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BakeryHouse.Helper;
using BakeryHouse.Models;
using BakeryHouse.Data;
using Microsoft.AspNetCore.Authorization;
using BakeryHouse.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BakeryHouse.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private BakeryHouseContext context;
        public CartController(BakeryHouseContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = context.Klanten.FirstOrDefault(k => k.UserId == userid);
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            OrderViewModel viewModel = new OrderViewModel
            {
                Klant = klant,
                order = new Order(),
                Today = today,
                afhaalpunten = await context.Afhaalpunten.ToListAsync()
            };
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new List<Item>();
            }
            viewModel.Items = cart;
            viewModel.Total = cart.Sum(i => i.product.Prijs * i.Aantal);
            return View(viewModel);
        }


        public IActionResult Buy(int? id, int Aantal)
        {
            if(Aantal <= 0)
            {
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<Item>();
                cart.Add(new Item() { product = context.Producten.Find(id),Aantal = Aantal});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item(){ product = context.Producten.Find(id), Aantal = Aantal });
                }
                else
                {
                    cart[index].Aantal+= Aantal;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        private int Exists(List<Item> cart,int? id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult Delitem(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            cart.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
