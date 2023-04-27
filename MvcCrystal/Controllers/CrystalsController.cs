using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCrystal.Data;
using MvcCrystal.Models;

namespace MvcCrystal.Controllers
{
    public class CrystalsController : Controller
    {
        private readonly MvcCrystalContext _context;

        public CrystalsController(MvcCrystalContext context)
        {
            _context = context;
        }

        // GET: Crystals
        public async Task<IActionResult> Index()
        {
              return _context.Crystal != null ? 
                          View(await _context.Crystal.ToListAsync()) :
                          Problem("Entity set 'MvcCrystalContext.Crystal'  is null.");
        }

        // GET: Crystals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Crystal == null)
            {
                return NotFound();
            }

            var crystal = await _context.Crystal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crystal == null)
            {
                return NotFound();
            }

            return View(crystal);
        }

        // GET: Crystals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crystals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExtractionDate,Color,Price")] Crystal crystal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crystal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crystal);
        }

        // GET: Crystals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Crystal == null)
            {
                return NotFound();
            }

            var crystal = await _context.Crystal.FindAsync(id);
            if (crystal == null)
            {
                return NotFound();
            }
            return View(crystal);
        }

        // POST: Crystals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ExtractionDate,Color,Price")] Crystal crystal)
        {
            if (id != crystal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crystal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrystalExists(crystal.Id))
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
            return View(crystal);
        }

        // GET: Crystals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Crystal == null)
            {
                return NotFound();
            }

            var crystal = await _context.Crystal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crystal == null)
            {
                return NotFound();
            }

            return View(crystal);
        }

        // POST: Crystals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Crystal == null)
            {
                return Problem("Entity set 'MvcCrystalContext.Crystal'  is null.");
            }
            var crystal = await _context.Crystal.FindAsync(id);
            if (crystal != null)
            {
                _context.Crystal.Remove(crystal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrystalExists(int id)
        {
          return (_context.Crystal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
