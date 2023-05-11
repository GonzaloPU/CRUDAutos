using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDAutosv.Models;

namespace CRUDAutosv.Controllers
{
    public class AutoesController : Controller
    {
        private readonly AutosContext _context;

        public AutoesController(AutosContext context)
        {
            _context = context;
        }

        // GET: Autoes
        public async Task<IActionResult> Index(string Search, int anio)

        {
            //Realizamos la condición para filtrar por Modelo, Marca y año
            var autos = from auto in _context.Autos select auto;

            if (!String.IsNullOrEmpty(Search))
            {
                   autos = autos.Where(e => e.Marca!.Contains(Search) || e.Modelo!.Contains(Search) || e.Anio.ToString().Contains(Search));
            }
          

            return View(await autos.ToListAsync()); 
                        
        }

        // GET: Autoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.IdAuto == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Autoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAuto,Marca,Modelo,Color,Patente,Anio")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auto);
        }

        // GET: Autoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View(auto);
        }

        // POST: Autoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAuto,Marca,Modelo,Color,Patente,Anio")] Auto auto)
        {
            if (id != auto.IdAuto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.IdAuto))
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
            return View(auto);
        }

        // GET: Autoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.IdAuto == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Autoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autos == null)
            {
                return Problem("Entity set 'AutosContext.Autos'  is null.");
            }
            var auto = await _context.Autos.FindAsync(id);
            if (auto != null)
            {
                _context.Autos.Remove(auto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
          return (_context.Autos?.Any(e => e.IdAuto == id)).GetValueOrDefault();
        }
    }
}
