#pragma checksum "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e793b9029337116073d842ce2c66eb9a6ae2297"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\_ViewImports.cshtml"
using webBancoGeneroso;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\_ViewImports.cshtml"
using webBancoGeneroso.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e793b9029337116073d842ce2c66eb9a6ae2297", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94ca45951f9f8f558e15ed99d070e303bcd6b506", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = Model == null ? "Ocorreu um Erro!" : Model.Titulo;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\Shared\Error.cshtml"
 if (Model == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        <h2>Atenção! Ocorreu um erro. Contate o administrador do sistema.</h2>\r\n    </p>\r\n");
#nullable restore
#line 11 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\Shared\Error.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 >");
#nullable restore
#line 14 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\Shared\Error.cshtml"
    Write(Html.Raw(Model.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <h2 class=\"text-danger\">");
#nullable restore
#line 15 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\Shared\Error.cshtml"
                       Write(Html.Raw(Model.Mensagem));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 16 "C:\_workspace\Consultoria CRS\webBancoGeneroso\Views\Shared\Error.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
