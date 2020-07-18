using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using webBancoGeneroso.Models;

namespace webBancoGeneroso.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IConfiguration _config;

        public RegisterModel(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IHostingEnvironment env,
            IConfiguration config
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _appEnvironment = env;
            _config = config;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public string PhotoPath { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(20, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 2)]
            [Display(Name = "Nome")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(10, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 4)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirma Senha")]
            [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Foto")]
            public IFormFile PhotoPath { get; set; }

            [Phone]
            [Display(Name = "Telefone")]
            public string PhoneNumber { get; set; }

            public string Id { get; set; }

            public IEnumerable<string> lstSelGrupoAcesso { get; set; }


            public IEnumerable<GruposAcesso> lstGrupoAcesso { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null, IFormFile photouser = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var caminhoFoto = photouser != null ?
                                    photouser.FileName :
                                        Input.PhotoPath != null ?
                                        Input.PhotoPath.FileName :
                                        null;

                string nomeArquivo = string.Concat("foto_",
                                        Input.UserName,
                                        DateTime.Now.Millisecond.ToString(),
                                        ".png");

                if (!string.IsNullOrEmpty(caminhoFoto))
                {
                    string caminhoDestinoArquivoOriginal = string.Concat(
                        _appEnvironment.WebRootPath,
                        _config.GetValue<string>("FolderImg"),
                        nomeArquivo);

                    //ajustar
                    using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
                    {
                        await photouser.CopyToAsync(stream);
                    }
                }

                var user = new UserCustomerModel
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    EmailConfirmed = true,
                    PhotoIdPath = nomeArquivo,
                    PhoneNumber = Input.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário criado com sucesso.");
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
