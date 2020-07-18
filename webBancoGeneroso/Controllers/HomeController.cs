using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webBancoGeneroso.Models;

namespace webBancoGeneroso.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id?}")]
        public IActionResult Error(int? id)
        {
            var errorModel = new ErrorViewModel();
            errorModel.ErrorCode = id.HasValue ? id.Value : 500;

            if (id == 500)
            {
                errorModel.Mensagem = "Ocorreu um erro. Tente novamente mais tarde ou contate nosso suporte.";
                errorModel.Titulo = "Ocorreu um erro!"; 
            }
            else if (id == 404)
            {
                errorModel.Mensagem = "A página solicitada não foi encontrada. <br />Em caso de dúvida entre em contato com o suporte.";
                errorModel.Titulo = "Página não encontrada!"; 
            }
            else if(id == 403)
            {
                errorModel.Mensagem = "Usuário sem permissão para esta funcionalidade.";
                errorModel.Titulo = "Acesso Negado";
            }
            else
            {
                return StatusCode(404);
            }
            return View("Error", errorModel);
        }
    }
}
