﻿using System;
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
    public class CardsController : Controller
    {
        private readonly MvcCrystalContext _context;

        public CardsController(MvcCrystalContext context)
        {
            _context = context;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
              return _context.Cards != null ? 
                          View(await _context.Cards.ToListAsync()) :
                          Problem("Entity set 'MvcCrystalContext.Cards'  is null.");
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Designer,Price")] Cards cards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cards);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }
            return View(cards);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Designer,Price")] Cards cards)
        {
            if (id != cards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardsExists(cards.Id))
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
            return View(cards);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cards == null)
            {
                return NotFound();
            }

            var cards = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cards == null)
            {
                return Problem("Entity set 'MvcCrystalContext.Cards'  is null.");
            }
            var cards = await _context.Cards.FindAsync(id);
            if (cards != null)
            {
                _context.Cards.Remove(cards);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardsExists(int id)
        {
          return (_context.Cards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
