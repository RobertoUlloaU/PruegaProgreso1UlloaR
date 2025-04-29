using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruegaProgreso1UlloaR.Models;

namespace PruegaProgreso1UlloaR.Controllers
{
    public class RecompensasController : Controller
    {
        private readonly DBSqlServerUlloaRoberto _context;

        public RecompensasController(DBSqlServerUlloaRoberto context)
        {
            _context = context;
        }

        // GET: Recompensas
        public async Task<IActionResult> Index()
        {
            var dBSqlServerUlloaRoberto = _context.Recompensa.Include(r => r.Cliente);
            return View(await dBSqlServerUlloaRoberto.ToListAsync());
        }

        // GET: Recompensas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensa = await _context.Recompensa
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recompensa == null)
            {
                return NotFound();
            }

            return View(recompensa);
        }

        // GET: Recompensas/Create
        public IActionResult Create()
        {
            ViewData["ClienteIdentificacion"] = new SelectList(_context.Cliente, "Identificacion", "Identificacion");
            return View();
        }

        // POST: Recompensas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaInicio,PuntosAcumulados,TipoRecompensa,ClienteIdentificacion")] Recompensa recompensa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recompensa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteIdentificacion"] = new SelectList(_context.Cliente, "Identificacion", "Identificacion", recompensa.ClienteIdentificacion);
            return View(recompensa);
        }

        // GET: Recompensas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensa = await _context.Recompensa.FindAsync(id);
            if (recompensa == null)
            {
                return NotFound();
            }
            ViewData["ClienteIdentificacion"] = new SelectList(_context.Cliente, "Identificacion", "Identificacion", recompensa.ClienteIdentificacion);
            return View(recompensa);
        }

        // POST: Recompensas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaInicio,PuntosAcumulados,TipoRecompensa,ClienteIdentificacion")] Recompensa recompensa)
        {
            if (id != recompensa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recompensa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecompensaExists(recompensa.Id))
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
            ViewData["ClienteIdentificacion"] = new SelectList(_context.Cliente, "Identificacion", "Identificacion", recompensa.ClienteIdentificacion);
            return View(recompensa);
        }

        // GET: Recompensas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recompensa = await _context.Recompensa
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recompensa == null)
            {
                return NotFound();
            }

            return View(recompensa);
        }

        // POST: Recompensas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recompensa = await _context.Recompensa.FindAsync(id);
            if (recompensa != null)
            {
                _context.Recompensa.Remove(recompensa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecompensaExists(int id)
        {
            return _context.Recompensa.Any(e => e.Id == id);
        }
    }
}
