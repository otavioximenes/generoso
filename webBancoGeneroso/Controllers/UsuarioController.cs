using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webBancoGeneroso.Data;
using webBancoGeneroso.Models;
using webBancoGeneroso.Utils;

namespace webBancoGeneroso.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IConfiguration _config;

        public UsuarioController(ApplicationDbContext context,
            IConfiguration config,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IHostingEnvironment appEnvironment
            )
        {
            _context = context;
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var lst = new List<UsuarioSistema>();
            lst = await _context.usuarioSistemas.ToListAsync();

            //List<UserCustomerModel> listUsers = new List<UserCustomerModel>();
            //var users = await _context.Users.ToListAsync();
            //listUsers = (from list in users
            //             select new UserCustomerModel()
            //             {
            //                 Id = list.Id,
            //                 UserName = list.UserName,
            //                 Email = list.Email,
            //                 PhoneNumber = list.PhoneNumber
            //             }).ToList();
            return View(lst);
        }

        // GET: TiposBancos/Create
        public async Task<IActionResult> Create()
        {            
            TempData["lstGrupoAcesso"] = GetListGrupoAcesso().Result;
            return View();
        }

        private async Task<List<GruposAcesso>> GetListGrupoAcesso()
        {
            return await _context.gruposAcessos.ToListAsync();
        }

        // GET: TiposBancos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return await DetalhesEdit(id);
        }

        private async Task<UsuarioSistema> GetUsuario(int id)
        {
            var usuario = await _context.usuarioSistemas
                .FirstOrDefaultAsync(m => m.Id == id);

            var lstUsuario = await _context.UsuarioGruposAcessos
                                                        .Where(x => x.IdUsuarioSistema == id)
                                                        .ToListAsync();
            var lstgrupoAcesso = await _context.gruposAcessos.ToListAsync();

            List<GruposAcesso> lstGrupo = (from grupo in lstgrupoAcesso
                                           join usuariogrupo in lstUsuario
                                           on grupo.Id equals usuariogrupo.IdGrupoAcessos
                                           select new GruposAcesso
                                           {
                                               Id = grupo.Id,
                                               PageAcesso = grupo.PageAcesso,
                                               Role = grupo.Role,
                                               UsuarioGruposAcesso = grupo.UsuarioGruposAcesso
                                           }
                          ).ToList();

            TempData["lstGrupoAcessoDetales"] = lstGrupo;
            TempData["lstGrupoAcesso"] = lstgrupoAcesso;
            return usuario;
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return await DetalhesEdit(id);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var usuario = await _context.usuarioSistemas.FindAsync(id);
            if (!string.IsNullOrEmpty(usuario.GuidId))
            {
                //deleta tabela aspnetusers
                var aspUser = await _context.Users.FindAsync(usuario.GuidId);
                _context.Users.Remove(aspUser);
                await _context.SaveChangesAsync();
            }

            //drop tabela usuarios
            _context.usuarioSistemas.Remove(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> DetalhesEdit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var usuario = await GetUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public async Task<IActionResult> Editar(int id)
        {
            return await DetalhesEdit(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, UsuarioSistema users, Microsoft.AspNetCore.Http.IFormCollection collection)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //getUser
                    var user = await _userManager.GetUserAsync(User);

                    //deleta claims do user
                    var claimsUser = await _userManager.GetClaimsAsync(user);
                    await _userManager.RemoveClaimsAsync(user, claimsUser);

                   //delete 
                    var useracesso = _context.UsuarioGruposAcessos.Where(g => g.IdUsuarioSistema == id);
                     _context.UsuarioGruposAcessos.RemoveRange(useracesso);
                    await _context.SaveChangesAsync();

                    //efetua a alteração
                    user.Email = users.Email;
                    user.PhoneNumber = users.Telefone;
                    user.UserName = users.Nome;
                    _context.Users.Update(user);
                    _context.usuarioSistemas.Update(users);
                    
                    //salva claims
                    InsertClaimRoles((UserCustomerModel)user, users, collection); 
                    await _context.SaveChangesAsync();                     
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
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
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, UsuarioSistema users, Microsoft.AspNetCore.Http.IFormCollection collection)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //upload foto
                    var user = await InsertIdentity(collection, users);
                    if (user != null)
                    {
                        users.GuidId = user.Id;

                        //create usuarios
                        _context.Add(users);
                        InsertClaimRoles(user, users, collection);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return new StatusCodeResult(500);
                    }
                }
            }
            return View(users);
        }

        private async void InsertClaimRoles(UserCustomerModel user,UsuarioSistema users, Microsoft.AspNetCore.Http.IFormCollection collection)
        {
            //create relacao
            var chks = (from itens in collection.Keys
                        where itens.Contains("chk_")
                        select itens.Replace("chk_", string.Empty)).ToList();

            var lstGrupoAcesso = TempData["lstGrupoAcesso"] == null ? GetListGrupoAcesso().Result : (List<GruposAcesso>)TempData["lstGrupoAcesso"];
             
            foreach (var item in chks)
            {
                var useracesso = new UsuarioGruposAcesso();
                useracesso.IdGrupoAcessos = Convert.ToInt64(item);
                useracesso.IdUsuarioSistema = users.Id;
                _context.Add(useracesso);

                //salva na claims                            
                var itemAcesso = lstGrupoAcesso.Find(p => p.Id == Convert.ToInt64(item.ToString()));
                if (itemAcesso != null)
                {
                    await _userManager.AddClaimAsync(user,
                        new Claim(itemAcesso.PageAcesso, ConstantPermissions.todasPermission, itemAcesso.PageAcesso, users.GuidId));
                }
            }
        }

        private async Task<UserCustomerModel> InsertIdentity(Microsoft.AspNetCore.Http.IFormCollection collection,
                                                                UsuarioSistema users)
        {
            string caminhoDestinoArquivoOriginal = await Uploadfile(collection, users.Nome);
            if (!string.IsNullOrEmpty(caminhoDestinoArquivoOriginal))
            {
                users.PathPhoto = caminhoDestinoArquivoOriginal;
            }

            //add user no aspnetuser
            var user = new UserCustomerModel
            {
                UserName = users.Nome,
                Email = users.Email,
                EmailConfirmed = true,
                PhotoIdPath = users.PathPhoto,
                PhoneNumber = users.Telefone,
            };

            var result = await _userManager.CreateAsync(user, users.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return user;
        }

        private async Task<string> Uploadfile(Microsoft.AspNetCore.Http.IFormCollection collection, string Nome)
        {
            string retcaminho = string.Empty;
            var files = collection.Files;

            if (files != null)
            {
                var arquivoFoto = files.FirstOrDefault();

                string nomeArquivo = string.Concat("foto_",
                                        Nome,
                                        DateTime.Now.Millisecond.ToString(),
                                        ".png");

                string caminhoDestinoArquivoOriginal = string.Concat(
                    _appEnvironment.WebRootPath,
                    _config.GetValue<string>("FolderImg"),
                    nomeArquivo);

                //ajustar
                using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
                {
                    await arquivoFoto.CopyToAsync(stream);
                }
                return caminhoDestinoArquivoOriginal;
            }
            return retcaminho;
        }

        private bool UsersExists(Int64 id)
        {
            return _context.usuarioSistemas.Any(e => e.Id == id);
        }

    }
}
