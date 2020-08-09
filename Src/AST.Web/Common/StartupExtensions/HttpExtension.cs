using System;
using AST.Application.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace AST.Web.Common.StartupExtensions
{
    public static class HttpExtensions
    {
        public static IServiceCollection AddCustomizedHttp(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpClient("Bar", c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("HttpClients:Bar"));
                    // c.DefaultRequestHeaders.Add("", "");
                })
                .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(500)))
                .AddTypedClient(c => Refit.RestService.For<IBar>(c));

            return services;
        }
    }
}
