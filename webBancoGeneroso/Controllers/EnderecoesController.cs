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
    public class EnderecoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnderecoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enderecoes
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Endereco.Include(e => e.Cliente);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: Enderecoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Enderecoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF");
            return View();
        }

        // POST: Enderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Logradouro,Numero,Complemento,Cep,Bairro,Cidade,Estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", endereco.ClienteId);
            return View(endereco);
        }

        // GET: Enderecoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", endereco.ClienteId);
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ClienteId,Logradouro,Numero,Complemento,Cep,Bairro,Cidade,Estado")] Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<Clientes>(), "Id", "CPF", endereco.ClienteId);
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(long id)
        {
            return _context.Endereco.Any(e => e.Id == id);
        }
    }
}
