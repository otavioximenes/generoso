using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Extensions
{
    public static class ActionResultExtensions
    {
        /// <summary>
        /// Redireciona para uma ActionResult retornando uma mensagem de confirmação para a View
        /// </summary>
        /// <param name="actionResult"></param>
        /// <param name="mensagem">Mensagem a ser exibida</param>
        /// <param name="titulo">titulo a ser exibido, sendo omitido apresenta defaut 'Atenção'</param>
        /// <returns></returns>
        public static IActionResult Mensagem(this ActionResult actionResult, string mensagem, string titulo = "Atenção")
        {
            return new TempDataActionResult (actionResult, mensagem, titulo);
        }
    }

    public class TempDataActionResult : IActionResult
    {
        private readonly ActionResult _actionResult;
        private readonly string _mensagem;
        private readonly string _titulo;
        private readonly Controller _context;

        public TempDataActionResult(ActionResult actionResult, string Mensagem, string Titulo)
        {
            _actionResult = actionResult;
            _mensagem = Mensagem;
            _titulo = Titulo;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            _context.TempData["Mensagem"] = _mensagem;
            _context.TempData["Titulo"] = _titulo;
            context.HttpContext = _context.HttpContext;
            return _actionResult.ExecuteResultAsync(context);
        }

        //public override void ExecuteResult(ControllerContext context)
        //{
        //    context.Controller.TempData["Mensagem"] = _mensagem;
        //    context.Controller.TempData["Titulo"] = _titulo;
        //    _actionResult.ExecuteResult(context);
        //}

        //public Task ExecuteResultAsync(ActionContext context, ControllerContext contextController)
        //{ 
        //    return _actionResult.ExecuteResultAsync(context);
        //}
    }
}
