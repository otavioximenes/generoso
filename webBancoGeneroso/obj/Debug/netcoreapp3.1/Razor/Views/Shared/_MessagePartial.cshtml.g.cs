#pragma checksum "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\Shared\_MessagePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71d1de0f0e2e6b18bccf32fd2005248aa9beee6f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MessagePartial), @"mvc.1.0.view", @"/Views/Shared/_MessagePartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\_ViewImports.cshtml"
using webBancoGeneroso;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\_ViewImports.cshtml"
using webBancoGeneroso.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71d1de0f0e2e6b18bccf32fd2005248aa9beee6f", @"/Views/Shared/_MessagePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94ca45951f9f8f558e15ed99d070e303bcd6b506", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MessagePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\Shared\_MessagePartial.cshtml"
  
    var Mensagem = "";
    var Titulo = "";

    if (TempData.Peek("Mensagem") != null)
    {
        Mensagem = TempData.Peek("Mensagem").ToString();
        Titulo = TempData.Peek("Titulo").ToString();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\Shared\_MessagePartial.cshtml"
 if (Mensagem != "")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <!--Formulario principal para Display de Mensagens /Views/shared/_Mensagem.cshtml-->
    <div id=""ModalMensagem"" class=""modal fade"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>
                    <h4 class=""modal-title"">");
#nullable restore
#line 20 "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\Shared\_MessagePartial.cshtml"
                                       Write(Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n                <div class=\"modal-body\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-12 text-center\">\r\n                            ");
#nullable restore
#line 25 "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\Shared\_MessagePartial.cshtml"
                       Write(Html.Raw(Mensagem));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-sm btn-default"" data-dismiss=""modal"">OK</button>
                </div>
            </div>
        </div>
    </div>
");
            WriteLiteral("    <script type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n        $(\"#ModalMensagem\").modal(\'show\');\r\n    });\r\n    </script>\r\n");
            WriteLiteral("    <!--Fim Formulario principal para Display de Mensagens -->\r\n");
#nullable restore
#line 43 "C:\_workspace\Consultoria CRS\webBancoGeneroso - editado\Views\Shared\_MessagePartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--Formulario principal para Display de Mensagem de Confirmação /Views/shared/_Mensagem.cshtml-->

<div id=""ModalConfirma"" class=""modal fade"">
    <div class=""modal-dialog"">
        <div class=""modal-content"" id=""BodyConfirma"">
            <!--Conteudo Dinamico-->
        </div>
    </div>
</div>

<script type=""text/javascript"">

    // Funcao para Carregar Mensagem de confirmação, se teclar no botão SIM desvia para o link informado
    function MensagemConfirma(Titulo, Mensagem, Link)
    {
        var data ='<div class=""modal-header"">'+
                  '<button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>'+
                  '<h4 class=""modal-title"">'+Titulo+'</h4>'+
                  '</div>'+
                  '<div class=""modal-body"">'+
                  '<div class=""row"">'+
                  '<div class=""col-md-12 text-center"">'+Mensagem+'</div>'+
                  '</div>'+
                  '</div>'+
                  '<div class=""mo");
            WriteLiteral(@"dal-footer"">'+
                  '<button type=""button"" class=""btn btn-sm btn-default"" data-dismiss=""modal"">Não</button>' +
                  '<a href=""'+Link+'"" class=""btn btn-sm btn-default"">Sim</a>'+
                  '</div>';
        $('#BodyConfirma').html(data);
        $(""#ModalConfirma"").modal('show');
    }

    // Funcao para Carregar Mensagem
    function Mensagem(Titulo, Mensagem) {
        var data = '<div class=""modal-header"">' +
                  '<button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>' +
                  '<h4 class=""modal-title"">' + Titulo + '</h4>' +
                  '</div>' +
                  '<div class=""modal-body"">' +
                  '<div class=""row"">' +
                  '<div class=""col-md-12 text-center"">' + Mensagem + '</div>' +
                  '</div>' +
                  '</div>' +
                  '<div class=""modal-footer"">' +
                  '<button type=""button"" class=""btn btn-sm btn-default""");
            WriteLiteral(" data-dismiss=\"modal\">OK</button>\' +\r\n                  \'</div>\';\r\n        $(\'#BodyConfirma\').html(data);\r\n        $(\"#ModalConfirma\").modal(\'show\');\r\n    }\r\n\r\n</script> \r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591