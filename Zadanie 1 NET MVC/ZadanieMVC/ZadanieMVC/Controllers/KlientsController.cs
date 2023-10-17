﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZadanieMVC.Context;
using ZadanieMVC.Models;

namespace ZadanieMVC.Controllers
{
    public class KlientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klients
        public async Task<IActionResult> Index()
        {
            return _context.Klienci != null ?
                        View(await _context.Klienci.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Klienci'  is null.");
        }

        // GET: Klients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klienci == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // GET: Klients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,PESEL,BirthYear,Plec")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klienci == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienci.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // POST: Klients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,PESEL,BirthYear,Plec")] Klient klient)
        {
            if (id != klient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.Id))
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
            return View(klient);
        }

        // GET: Klients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klienci == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klienci == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Klienci'  is null.");
            }
            var klient = await _context.Klienci.FindAsync(id);
            if (klient != null)
            {
                _context.Klienci.Remove(klient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
            return (_context.Klienci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
