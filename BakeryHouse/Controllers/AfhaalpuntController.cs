using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BakeryHouse.Data;
using BakeryHouse.Models;
using BakeryHouse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BakeryHouse.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AfhaalpuntController : PartialController
    {
        private readonly BakeryHouseContext _context;

        public AfhaalpuntController(BakeryHouseContext context):base(context)
        {
            _context = context;
        }

        // GET: Afhaalpunt
        public async Task<IActionResult> Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            //    IndexAfhaalpuntViewModel viewModel = new IndexAfhaalpuntViewModel
            //    {
            //        Afhaalpunten = await _context.Afhaalpunten.ToListAsync()
            //};
            var model = await base.CreateModel<IndexAfhaalpuntViewModel>();
            model.Afhaalpunten = await _context.Afhaalpunten.ToListAsync();
            return View(model);
        }

        // GET: Afhaalpunt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var afhaalpunt = await _context.Afhaalpunten
                .FirstOrDefaultAsync(m => m.AfhaalpuntId == id);
            if (afhaalpunt == null)
            {
                return NotFound();
            }

            return View(afhaalpunt);
        }

        // GET: Afhaalpunt/Create
        public IActionResult Create()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            return View();
        }

        // POST: Afhaalpunt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AfhaalpuntId,Omschrijving,Adres,Postcode,stad")] Afhaalpunt afhaalpunt)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (ModelState.IsValid)
            {
                _context.Add(afhaalpunt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(afhaalpunt);
        }

        // GET: Afhaalpunt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var afhaalpunt = await _context.Afhaalpunten.FindAsync(id);
            if (afhaalpunt == null)
            {
                return NotFound();
            }
            return View(afhaalpunt);
        }

        // POST: Afhaalpunt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AfhaalpuntId,Omschrijving,Adres,Postcode,stad")] Afhaalpunt afhaalpunt)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id != afhaalpunt.AfhaalpuntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afhaalpunt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfhaalpuntExists(afhaalpunt.AfhaalpuntId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(afhaalpunt);
        }

        // GET: Afhaalpunt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            if (id == null)
            {
                return NotFound();
            }

            var afhaalpunt = await _context.Afhaalpunten
                .FirstOrDefaultAsync(m => m.AfhaalpuntId == id);
            if (afhaalpunt == null)
            {
                return NotFound();
            }

            return View(afhaalpunt);
        }

        // POST: Afhaalpunt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Klant klant = _context.Klanten.FirstOrDefault(k => k.UserId == userid);
            var afhaalpunt = await _context.Afhaalpunten.FindAsync(id);
            _context.Afhaalpunten.Remove(afhaalpunt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfhaalpuntExists(int id)
        {
            return _context.Afhaalpunten.Any(e => e.AfhaalpuntId == id);
        }
    }
}
