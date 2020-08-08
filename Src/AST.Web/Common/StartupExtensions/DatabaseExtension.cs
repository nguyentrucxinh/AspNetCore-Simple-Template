using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AST.Infrastructure.Data;

namespace AST.Web.Common.StartupExtensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(
                    options, configuration.GetValue<string>("DefaultConnection")));

            return services;
        }
    }
}
