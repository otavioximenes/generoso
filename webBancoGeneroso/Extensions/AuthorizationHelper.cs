using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using webBancoGeneroso.Utils;

namespace webBancoGeneroso.Extensions
{
    public class NecesseryPermission : IAuthorizationRequirement
    {
        public string Permission { get; set; }

        public NecesseryPermission(string permission)
        {
            Permission = permission;
        }
    }

    public class NecesseryPermissionHandler : AuthorizationHandler<NecesseryPermission>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NecesseryPermission requirement)
        {
            if (context.User.HasClaim(c => c.Type == ConstantPermissions.permission && c.Value.Contains(requirement.Permission)))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
