using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AST.Core.Interfaces;
using AST.Infrastructure.Data;
using AST.Application.Interfaces;
using AST.Application.Services;

namespace AST.Web.Common.StartupExtensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddCustomizedDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IFooRepository, FooRepository>();
            services.AddScoped<IFooService, FooService>();

            return services;
        }

        public static IApplicationBuilder UseCustomizedDependencyInjection(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
