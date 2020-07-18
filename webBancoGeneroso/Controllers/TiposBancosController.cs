using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Newtonsoft.Json;
using webBancoGeneroso.Data;
using webBancoGeneroso.Extensions;
using webBancoGeneroso.Models;
using webBancoGeneroso.Utils;

namespace webBancoGeneroso.Controllers
{
    public class TiposBancosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposBancosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposBancos
        public async Task<IActionResult> Index()
        {
             return View(await _context.TiposBancos.ToListAsync());
            //return View();
        }

        // GET: TiposBancos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposBancos = await _context.TiposBancos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposBancos == null)
            {
                return NotFound();
            }

            return View(tiposBancos);
        }

        // GET: TiposBancos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposBancos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome")] TiposBancos tiposBancos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposBancos);
                await _context.SaveChangesAsync();

                string mensagem = string.Format(ConstantMessage.msgInsert, "Banco");
                TempData["Mensagem"] = mensagem;
                TempData["Titulo"] = ConstantMessage.information;

                return RedirectToAction(nameof(Index));
            }
            return View(tiposBancos);
        }

        // GET: TiposBancos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposBancos = await _context.TiposBancos.FindAsync(id);
            if (tiposBancos == null)
            {
                return NotFound();
            }
            return View(tiposBancos);
        }

        // POST: TiposBancos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nome")] TiposBancos tiposBancos)
        {
            if (id != tiposBancos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposBancos);
                    await _context.SaveChangesAsync();

                    TempData["message"] = Menssager.SendMenssager(
                        ConstantMessage.information,
                         ConstantMessage.msgInsert, 
                         nameof(this.ControllerContext));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposBancosExists(tiposBancos.Id))
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
            return View(tiposBancos);
        }

        // GET: TiposBancos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposBancos = await _context.TiposBancos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposBancos == null)
            {
                return NotFound();
            }

            return View(tiposBancos);
        }

        // POST: TiposBancos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposBancos = await _context.TiposBancos.FindAsync(id);
            _context.TiposBancos.Remove(tiposBancos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposBancosExists(int id)
        {
            return _context.TiposBancos.Any(e => e.Id == id);
        }
    }
}
