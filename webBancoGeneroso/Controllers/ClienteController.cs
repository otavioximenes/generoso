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
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        //private void ComboTipoPessoa()
        //{
        //    List<string> lstTipoPessoa = new List<string>();
        //    lstTipoPessoa.Add(nameof(TipoPessoa.PessoaFisica));
        //    lstTipoPessoa.Add(nameof(TipoPessoa.PessoaJuridica));
        //    ViewData["TiposPessoas"] = new SelectList(lstTipoPessoa);
        //}

        public IActionResult Create()
        { 
            var clienteModel = new ClienteModel();
            return View(clienteModel);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //salva cliente
                    var _cliente = new Clientes();
                    _cliente = clienteModel.cliente;
                    _context.Add(_cliente);
                    await _context.SaveChangesAsync();

                    //salva contato
                    var _contatos = new Contato();
                    _contatos = clienteModel.contato;
                    _contatos.ClienteId = _cliente.Id;
                    _context.Add(_contatos); 

                    //salva endereco
                    var _endereco = new Endereco();
                    _endereco = clienteModel.endereco;
                    _endereco.ClienteId = _cliente.Id;
                    _context.Add(_endereco);
                    await _context.SaveChangesAsync();

                    //retorna para index
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }               
            }
            return View(clienteModel);
        }
    }
}
