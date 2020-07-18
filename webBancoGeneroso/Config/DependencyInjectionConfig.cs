using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using webBancoGeneroso.Extensions;

namespace webBancoGeneroso.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, NecesseryPermissionHandler>();
            return services;
        }
    }
}
