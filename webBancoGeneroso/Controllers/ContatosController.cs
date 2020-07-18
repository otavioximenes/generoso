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
    public class ContatosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContatosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.Contato.Include(c => c.Cliente);
            return View(await dbContext.ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF");
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Nome,Email,Telefone,Celular")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", contato.ClienteId);
            return View(contato);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", contato.ClienteId);
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ClienteId,Nome,Email,Telefone,Celular")] Contato contato)
        {
            if (id != contato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", contato.ClienteId);
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var contato = await _context.Contato.FindAsync(id);
            _context.Contato.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(long id)
        {
            return _context.Contato.Any(e => e.Id == id);
        }
    }
}
