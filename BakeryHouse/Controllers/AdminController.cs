using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BakeryHouse.Data;
using BakeryHouse.Helper;
using BakeryHouse.Models;
using BakeryHouse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakeryHouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly BakeryHouseContext _context;

        public AdminController(BakeryHouseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder,
             string currentFilter,
             string searchString,
             int? pageNumber)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            AdminViewModel viewModel = new AdminViewModel();
            viewModel.CurrentSort = sortOrder;
            viewModel.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            viewModel.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            viewModel.LeverDateSortParm = sortOrder == "LeverDate" ? "leverdate_desc" : "LeverDate";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            viewModel.CurrentFilter = searchString;

            var Orders = from o in _context.Orders.Include(o => o.Klant).Include(o => o.Afhaalpunt).Include(o => o.Orderlijnen).ThenInclude(ol => ol.Product)
                         select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                Orders = Orders.Where(o => o.Klant.Naam.Contains(searchString) || o.Afhaalpunt.Omschrijving.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    Orders = Orders.OrderByDescending(o => o.Klant.Naam);
                    break;
                case "Date":
                    Orders = Orders.OrderBy(o => o.Orderdatum);
                    break;
                case "date_desc":
                    Orders = Orders.OrderByDescending(o => o.Orderdatum);
                    break;
                case "LeverDate":
                    Orders = Orders.OrderBy(o => o.LeverDatum);
                    break;
                case "leverdate_desc":
                    Orders = Orders.OrderByDescending(o => o.LeverDatum);
                    break;
                default:
                    Orders = Orders.OrderBy(o => o.Klant.Naam);
                    break;
            }

            int pageSize = 4;
            viewModel.paginaList = await PaginatedList<Order>.CreateAsync(Orders.AsNoTracking(), pageNumber ?? 1, pageSize);

            return View(viewModel);

        }

        public IActionResult CrudPaginas()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            return View();
        }
    }
}
