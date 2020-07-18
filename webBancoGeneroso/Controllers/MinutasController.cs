using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webBancoGeneroso.Data;
using webBancoGeneroso.Models;

namespace webBancoGeneroso.Controllers
{
    public class MinutasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MinutasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Minutas
        public async Task<IActionResult> Index()
        {
            var bancoGenerosoDbContext = _context.Minuta.Include(m => m.Cliente);
            return View(await bancoGenerosoDbContext.ToListAsync());
        }

        // GET: Minutas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minuta = await _context.Minuta
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minuta == null)
            {
                return NotFound();
            }

            return View(minuta);
        }

        // GET: Minutas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF");
            return View();
        }

        // POST: Minutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,DataEmissao,DataVencimento,Adm,ValorAdmin,ClienteId")] Minuta minuta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(minuta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", minuta.ClienteId);
            return View(minuta);
        }

        // GET: Minutas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minuta = await _context.Minuta.FindAsync(id);
            if (minuta == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", minuta.ClienteId);
            return View(minuta);
        }

        // POST: Minutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Codigo,DataEmissao,DataVencimento,Adm,ValorAdmin,ClienteId")] Minuta minuta)
        {
            if (id != minuta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minuta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinutaExists(minuta.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", minuta.ClienteId);
            return View(minuta);
        }

        // GET: Minutas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minuta = await _context.Minuta
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (minuta == null)
            {
                return NotFound();
            }

            return View(minuta);
        }

        // POST: Minutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var minuta = await _context.Minuta.FindAsync(id);
            _context.Minuta.Remove(minuta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinutaExists(long id)
        {
            return _context.Minuta.Any(e => e.Id == id);
        }
    }
}
