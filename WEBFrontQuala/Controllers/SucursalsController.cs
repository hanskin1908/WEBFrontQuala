using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Update.Internal;
using WEBFrontQuala.Managers.Services;
using WEBFrontQuala.Models;

namespace WEBFrontQuala.Controllers
{
    public class SucursalsController : Controller
    {
        private readonly TestDbContext _context;
        ISucursalServicescs _serv;
        public SucursalsController(TestDbContext context,ISucursalServicescs service)
        {
            _serv = service;
            _context = context;
        }

        // GET: Sucursals
        public async Task<IActionResult> Index()
        {

            Response<Moneda_Sucursal> s = await _serv.consultartodassucursales();
            //var pruebaapiQContext = _context.Sucurs.Include(s => s.IdMonedaNavigation);
            return View(s.Lst);
        }

        // GET: Sucursals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals
                .Include(s => s.IdMonedaSucNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // GET: Sucursals/Create
        public IActionResult Create()
        {
            ViewData["IdMonedaSuc"] = new SelectList(_context.MonMoneda, "IdMoneda", "Descripcion");
            return View();
        }

        // POST: Sucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descripcion,Direccion,Identificacion,IdMonedaSuc")] Sucursal sucursal)
        {
      
            if (ModelState.IsValid)
            {
                HttpResponseMessage s = await _serv.CreatsucursaltAsync(sucursal);
                if (s.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
           

            }





            ViewData["IdMoneda"] = new SelectList(_context.MonMoneda, "IdMoneda", "Descripcion", sucursal.IdMonedaSuc);

            return View(sucursal);
        }

        // GET: Sucursals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sucursals == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursals.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            ViewData["IdMonedaSuc"] = new SelectList(_context.MonMoneda, "IdMoneda", "IdMoneda", sucursal.IdMonedaSuc);
            return View(sucursal);
        }

        // POST: Sucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Descripcion,Direccion,Identificacion,IdMonedaSuc")] Sucursal sucursal)
        {
            if (id != sucursal.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(sucursal.Codigo))
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
            ViewData["IdMonedaSuc"] = new SelectList(_context.MonMoneda, "IdMoneda", "Descripcion", sucursal.IdMonedaSuc);
            return View(sucursal);
        }

        // GET: Sucursals/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var sucursal = await _serv.consultarsucursal(id);
            
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal.UnitResp);
        }

        // POST: Sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          
       
            HttpResponseMessage s = await _serv.EliminarSucursal(id);
            if (s.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
          return _context.Sucursals.Any(e => e.Codigo == id);
        }
    }
}
