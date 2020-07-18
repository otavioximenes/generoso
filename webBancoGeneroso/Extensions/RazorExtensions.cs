using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUsers(page.Context, claimName, claimValue);
        }

        public static string IFClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUsers(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        public static IHtmlContent IFCLaimShow(this IHtmlContent page, HttpContext context ,string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUsers(context, claimName, claimValue) ? page : null;
        }

    }
}
