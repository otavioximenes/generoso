using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 
using System.Linq;
using System.Security.Claims;

namespace webBancoGeneroso.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidateClaimsUsers(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                        context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoAuthorizationFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }


    public class RequisitoAuthorizationFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoAuthorizationFilter(Claim Claim)
        {
            _claim = Claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!CustomAuthorization.ValidateClaimsUsers(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
