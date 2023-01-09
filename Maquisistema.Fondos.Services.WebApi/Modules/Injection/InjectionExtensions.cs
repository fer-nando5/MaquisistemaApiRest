using Maquisistema.Fondos.Application.Interface;
using Maquisistema.Fondos.Application.Main;
using Maquisistema.Fondos.Dominio.Core;
using Maquisistema.Fondos.Dominio.Interface;
using Maquisistema.Fondos.Infraestructura.Data;
using Maquisistema.Fondos.Infraestructura.Interface;
using Maquisistema.Fondos.Infraestructura.Repository;
using Maquisistema.Fondos.Transversal.Common;
using Maquisistema.Fondos.Transversal.Logging;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace Maquisistema.Fondos.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IProductDominio, ProductDominio>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDiscountProductRepository, DiscountProductRepository>();
            services.AddScoped<IDiscountProductDominio, DiscountProductDominio>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
