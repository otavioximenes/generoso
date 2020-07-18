using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webBancoGeneroso.Data;
using webBancoGeneroso.Extensions;
using webBancoGeneroso.Utils;

namespace webBancoGeneroso.Config
{
    public static class ContextConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            //services.AddAuthorization(options => {
            //    options.AddPolicy(ConstantPermissions.delete, policy => policy.Requirements.Add(new NecesseryPermission(ConstantPermissions.delete)));
            //    options.AddPolicy(ConstantPermissions.ready, policy => policy.Requirements.Add(new NecesseryPermission(ConstantPermissions.ready)));
            //    options.AddPolicy(ConstantPermissions.write, policy => policy.Requirements.Add(new NecesseryPermission(ConstantPermissions.write)));
            //    options.AddPolicy(ConstantPermissions.report, policy => policy.Requirements.Add(new NecesseryPermission(ConstantPermissions.report)));
            //});

            return services;
        }

        public static IServiceCollection AddContextDependecies(this IServiceCollection services, 
                                                                        IConfiguration configuration)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
