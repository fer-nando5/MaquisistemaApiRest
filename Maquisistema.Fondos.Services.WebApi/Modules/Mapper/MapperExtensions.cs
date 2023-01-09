
using AutoMapper;
using Maquisistema.Fondos.Transversal.Mapper;

namespace Maquisistema.Fondos.Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var MappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfile());
            });
            IMapper mapper = MappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
