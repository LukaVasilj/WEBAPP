﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBAPP.Context;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    public class TheatersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheatersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Theaters
        public async Task<IActionResult> Index()
        {
            return _context.theaters != null ?
                        View(await _context.theaters.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.theaters'  is null.");
        }

        // GET: Theaters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.theaters == null)
            {
                return NotFound();
            }

            var theater = await _context.theaters
                .FirstOrDefaultAsync(m => m.theaterid == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }

        // GET: Theaters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Theaters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,capacity")] Theater theater)
        {
            if (ModelState.IsValid)
            {
                // Generate a unique theaterid
                int maxTheaterId = await _context.theaters.MaxAsync(t => t.theaterid);
                theater.theaterid = maxTheaterId + 1;

                _context.Add(theater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theater);
        }


        // GET: Theaters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.theaters == null)
            {
                return NotFound();
            }

            var theater = await _context.theaters.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }
            return View(theater);
        }

        // POST: Theaters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("theaterid,name,capacity")] Theater theater)
        {
            if (id != theater.theaterid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheaterExists(theater.theaterid))
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
            return View(theater);
        }

        // GET: Theaters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.theaters == null)
            {
                return NotFound();
            }

            var theater = await _context.theaters
                .FirstOrDefaultAsync(m => m.theaterid == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }

        // POST: Theaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.theaters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.theaters' is null.");
            }

            // Delete associated records in customers_theaters table
            await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM customers_theaters WHERE theaterid = {id}");

            // Delete the theater
            var theater = await _context.theaters.FindAsync(id);
            if (theater != null)
            {
                _context.theaters.Remove(theater);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool TheaterExists(int id)
        {
            return (_context.theaters?.Any(e => e.theaterid == id)).GetValueOrDefault();
        }
    }
}
