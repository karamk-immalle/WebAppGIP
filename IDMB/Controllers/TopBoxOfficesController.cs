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
    public class TopBoxOfficesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopBoxOfficesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TopBoxOffices
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopBoxOffice.ToListAsync());
        }

        // GET: TopBoxOffices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBoxOffice = await _context.TopBoxOffice
                .SingleOrDefaultAsync(m => m.Id == id);
            if (topBoxOffice == null)
            {
                return NotFound();
            }

            return View(topBoxOffice);
        }

        // GET: TopBoxOffices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopBoxOffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rank,Title,Weekend,Gross,Week")] TopBoxOffice topBoxOffice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topBoxOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topBoxOffice);
        }

        // GET: TopBoxOffices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBoxOffice = await _context.TopBoxOffice.SingleOrDefaultAsync(m => m.Id == id);
            if (topBoxOffice == null)
            {
                return NotFound();
            }
            return View(topBoxOffice);
        }

        // POST: TopBoxOffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rank,Title,Weekend,Gross,Week")] TopBoxOffice topBoxOffice)
        {
            if (id != topBoxOffice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topBoxOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopBoxOfficeExists(topBoxOffice.Id))
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
            return View(topBoxOffice);
        }

        // GET: TopBoxOffices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topBoxOffice = await _context.TopBoxOffice
                .SingleOrDefaultAsync(m => m.Id == id);
            if (topBoxOffice == null)
            {
                return NotFound();
            }

            return View(topBoxOffice);
        }

        // POST: TopBoxOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topBoxOffice = await _context.TopBoxOffice.SingleOrDefaultAsync(m => m.Id == id);
            _context.TopBoxOffice.Remove(topBoxOffice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopBoxOfficeExists(int id)
        {
            return _context.TopBoxOffice.Any(e => e.Id == id);
        }
    }
}
