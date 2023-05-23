using System;
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
    public class ShowtimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowtimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Showtimes
        public async Task<IActionResult> Index()
        {
            var showtimes = await _context.showtimes
        .Include(s => s.theaters)
        .Include(s => s.movies)
        .ToListAsync();

            if (showtimes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.showtimes' is null.");
            }

            return View(showtimes);


        }

        // GET: Showtimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showtime = await _context.showtimes
                .Include(s => s.theaters)
                .Include(s => s.movies)
                .FirstOrDefaultAsync(m => m.showtimeid == id);

            if (showtime == null)
            {
                return NotFound();
            }

            return View(showtime);
        }

        // GET: Showtimes/Create
        public IActionResult Create()
        {
            


            var theaters = _context.theaters.Select(t => new SelectListItem
            {
                Value = t.theaterid.ToString(),
                Text = t.name
            }).ToList();

            var movies = _context.movies.Select(m => new SelectListItem
            {
                Value = m.movieid.ToString(),
                Text = m.title
            }).ToList();

            if (theaters == null || theaters.Count == 0 || movies == null || movies.Count == 0)
            {
                // Handle the case when theaters or movies are not available
                // You can redirect to an error page or take appropriate action
                return RedirectToAction("NoDataAvailable");
            }

            // Add logging or debugging statements here
            foreach (var theater in theaters)
            {
                // Log or print theater details
                Console.WriteLine($"Theater ID: {theater.Value}, Name: {theater.Text}");
            }

            ViewBag.theaters = theaters;
            ViewBag.movies = movies;

            return View();
        }

        public IActionResult NoDataAvailable()
        {
            // Perform any necessary logic
            Console.WriteLine("There is no data available.");

            // You can return a different view or perform additional actions if needed
            return RedirectToAction("Index");
        }

        // POST: Showtimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("showtimeid,theaterid,movieid,price,starttime,endtime")] Showtime showtime)
        {

            showtime.starttime = showtime.starttime.ToUniversalTime();
            showtime.endtime = showtime.endtime.ToUniversalTime();

            if (ModelState.IsValid)
            {
                _context.Add(showtime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(showtime);
        }

        // GET: Showtimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.showtimes == null)
            {
                return NotFound();
            }

            var showtime = await _context.showtimes.FindAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }

            // Retrieve theaters and movies data and populate ViewBag
            var theaters = await _context.theaters.ToListAsync();
            var movies = await _context.movies.ToListAsync();
            ViewBag.theaters = new SelectList(theaters, "theaterid", "name", showtime.theaterid);
            ViewBag.movies = new SelectList(movies, "movieid", "title", showtime.movieid);

            return View(showtime);
        }

        // POST: Showtimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("showtimeid,theaterid,movieid,price,starttime,endtime")] Showtime showtime)
        {

            showtime.starttime = showtime.starttime.ToUniversalTime();
            showtime.endtime = showtime.endtime.ToUniversalTime();

            if (id != showtime.showtimeid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showtime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowtimeExists(showtime.showtimeid))
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
            return View(showtime);
        }

        // GET: Showtimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.showtimes == null)
            {
                return NotFound();
            }

            var showtime = await _context.showtimes
                .FirstOrDefaultAsync(m => m.showtimeid == id);
            if (showtime == null)
            {
                return NotFound();
            }

            return View(showtime);
        }

        // POST: Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.showtimes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.showtimes'  is null.");
            }
            var showtime = await _context.showtimes.FindAsync(id);
            if (showtime != null)
            {
                _context.showtimes.Remove(showtime);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowtimeExists(int id)
        {
            return (_context.showtimes?.Any(e => e.showtimeid == id)).GetValueOrDefault();
        }

    }



}
