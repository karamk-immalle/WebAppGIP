using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IDMB.Data;
using IDMB.Models;

namespace IDMB.Controllers
{
    public class TvShowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TvShowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TvShows
        public async Task<IActionResult> Index(string searchString)
        {
            var tvshows = from m in _context.TvShows
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                tvshows = tvshows.Where(s => s.Naam.Contains(searchString));
            }

            return View(await tvshows.ToListAsync());
        }

        // GET: TvShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShows = await _context.TvShows
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tvShows == null)
            {
                return NotFound();
            }

            return View(tvShows);
        }

        // GET: TvShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvShows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,DatumVanPublicatie,Genre,AantalAflevering")] TvShows tvShows)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvShows);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvShows);
        }

        // GET: TvShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShows = await _context.TvShows.SingleOrDefaultAsync(m => m.Id == id);
            if (tvShows == null)
            {
                return NotFound();
            }
            return View(tvShows);
        }

        // POST: TvShows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,DatumVanPublicatie,Genre,AantalAflevering")] TvShows tvShows)
        {
            if (id != tvShows.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvShows);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvShowsExists(tvShows.Id))
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
            return View(tvShows);
        }

        // GET: TvShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvShows = await _context.TvShows
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tvShows == null)
            {
                return NotFound();
            }

            return View(tvShows);
        }

        // POST: TvShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvShows = await _context.TvShows.SingleOrDefaultAsync(m => m.Id == id);
            _context.TvShows.Remove(tvShows);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvShowsExists(int id)
        {
            return _context.TvShows.Any(e => e.Id == id);
        }
    }
}
