using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bakery2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bakery2.Controllers
{
    public class BakersController : Controller
    {
        private readonly Bakery2Context _context;

        public BakersController(Bakery2Context context)
        {
            _context = context;
        }

        // GET: Bakers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Baker.ToListAsync());
        }

        // GET: Bakers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Baker == null)
            {
                return NotFound();
            }

            var baker = await _context.Baker
                .FirstOrDefaultAsync(m => m.BakerId == id);
            if (baker == null)
            {
                return NotFound();
            }

            return View(baker);
        }

        // GET: Bakers/Create
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BakerId,FirstName,LastName")] Baker baker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baker);
        }

        // GET: Bakers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Baker == null)
            {
                return NotFound();
            }

            var baker = await _context.Baker.FindAsync(id);
            if (baker == null)
            {
                return NotFound();
            }
            return View(baker);
        }

        // POST: Bakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BakerId,FirstName,LastName")] Baker baker)
        {
            if (id != baker.BakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BakerExists(baker.BakerId))
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
            return View(baker);
        }

        // GET: Bakers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Baker == null)
            {
                return NotFound();
            }

            var baker = await _context.Baker
                .FirstOrDefaultAsync(m => m.BakerId == id);
            if (baker == null)
            {
                return NotFound();
            }

            return View(baker);
        }

        // POST: Bakers/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Baker == null)
            {
                return Problem("Entity set 'Bakery2Context.Baker'  is null.");
            }
            var baker = await _context.Baker.FindAsync(id);
            if (baker != null)
            {
                _context.Baker.Remove(baker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BakerExists(long id)
        {
          return _context.Baker.Any(e => e.BakerId == id);
        }
    }
}
