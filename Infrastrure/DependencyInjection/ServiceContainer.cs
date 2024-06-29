


using Application.Contracts;
using Infrastrure.Data;
using Infrastrure.Repon;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Infrastrure.DependencyInjection
{
    public static class ServiceContainer
    {
        //Add Db
        public static IServiceCollection InFrastrutureServics(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("Default"),
                b=>b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)), ServiceLifetime.Scoped);

            //Sử dụng dịch vụ
            services.AddScoped<IPeople, PeopleRepon>();

            return services;
        }
    }
}
