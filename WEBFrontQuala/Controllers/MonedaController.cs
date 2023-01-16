using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBFrontQuala.Models;

namespace WEBFrontQuala.Controllers
{
    public class MonedaController : Controller
    {
        private readonly TestDbContext _context;

        public MonedaController(TestDbContext context)
        {
            _context = context;
        }

        // GET: Moneda
        public async Task<IActionResult> Index()
        {
              return View(await _context.MonMoneda.ToListAsync());
        }

        // GET: Moneda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonMoneda == null)
            {
                return NotFound();
            }

            var monMonedum = await _context.MonMoneda
                .FirstOrDefaultAsync(m => m.IdMoneda == id);
            if (monMonedum == null)
            {
                return NotFound();
            }

            return View(monMonedum);
        }

        // GET: Moneda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMoneda,Descripcion")] MonMonedum monMonedum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monMonedum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monMonedum);
        }

        // GET: Moneda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonMoneda == null)
            {
                return NotFound();
            }

            var monMonedum = await _context.MonMoneda.FindAsync(id);
            if (monMonedum == null)
            {
                return NotFound();
            }
            return View(monMonedum);
        }

        // POST: Moneda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMoneda,Descripcion")] MonMonedum monMonedum)
        {
            if (id != monMonedum.IdMoneda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monMonedum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonMonedumExists(monMonedum.IdMoneda))
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
            return View(monMonedum);
        }

        // GET: Moneda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonMoneda == null)
            {
                return NotFound();
            }

            var monMonedum = await _context.MonMoneda
                .FirstOrDefaultAsync(m => m.IdMoneda == id);
            if (monMonedum == null)
            {
                return NotFound();
            }

            return View(monMonedum);
        }

        // POST: Moneda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonMoneda == null)
            {
                return Problem("Entity set 'TestDbContext.MonMoneda'  is null.");
            }
            var monMonedum = await _context.MonMoneda.FindAsync(id);
            if (monMonedum != null)
            {
                _context.MonMoneda.Remove(monMonedum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonMonedumExists(int id)
        {
          return _context.MonMoneda.Any(e => e.IdMoneda == id);
        }
    }
}
