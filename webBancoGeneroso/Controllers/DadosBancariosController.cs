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
    public class DadosBancariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosBancariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadosBancarios
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.DadosBancarios.Include(d => d.TiposBancos);
            return View(await dbContext.ToListAsync());
        }

        // GET: DadosBancarios/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosBancarios = await _context.DadosBancarios
                .Include(d => d.TiposBancos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosBancarios == null)
            {
                return NotFound();
            }

            return View(dadosBancarios);
        }

        // GET: DadosBancarios/Create
        public IActionResult Create()
        {
            ViewData["TiposBancosId"] = new SelectList(_context.TiposBancos, "Id","Nome");
            return View();
        }

        // POST: DadosBancarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TiposBancosId,CNPJ,Agencia,RazaoSocial,Numero")] DadosBancarios dadosBancarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosBancarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TiposBancosId"] = new SelectList(_context.TiposBancos, "Id", "Nome", dadosBancarios.TiposBancosId);
            return View(dadosBancarios);
        }

        // GET: DadosBancarios/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosBancarios = await _context.DadosBancarios.FindAsync(id);
            if (dadosBancarios == null)
            {
                return NotFound();
            }
            ViewData["TiposBancosId"] = new SelectList(_context.TiposBancos, "Id", "Nome", dadosBancarios.TiposBancosId);
            return View(dadosBancarios);
        }

        // POST: DadosBancarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TiposBancosId,CNPJ,Agencia,RazaoSocial,Numero")] DadosBancarios dadosBancarios)
        {
            if (id != dadosBancarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosBancarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosBancariosExists(dadosBancarios.Id))
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
            ViewData["TiposBancosId"] = new SelectList(_context.TiposBancos, "Codigo", "Nome", dadosBancarios.TiposBancosId);
            return View(dadosBancarios);
        }

        // GET: DadosBancarios/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosBancarios = await _context.DadosBancarios
                .Include(d => d.TiposBancos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosBancarios == null)
            {
                return NotFound();
            }

            return View(dadosBancarios);
        }

        // POST: DadosBancarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dadosBancarios = await _context.DadosBancarios.FindAsync(id);
            _context.DadosBancarios.Remove(dadosBancarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosBancariosExists(long id)
        {
            return _context.DadosBancarios.Any(e => e.Id == id);
        }
    }
}
