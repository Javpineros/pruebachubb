using AutoMapper;
using PruebaChubb.API.Mapping;
using PruebaChubb.Business;
using PruebaChubb.CI.Actions;
using PruebaChubb.Data.Dal;

namespace PruebaChubb.API
{
    public static class ServiceCollectionExtension
    {
        public static void AddAutoMapping(this IServiceCollection services)
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddActions(this IServiceCollection services)
        {
            services.AddScoped<IRuletaBusinessAction, RuletaBL>();
            services.AddScoped<IRuletaRepositoryAction, RuletaDal>();
            services.AddScoped<IApuestaBusinessAction, ApuestaBL>();
            services.AddScoped<IApuestaRepositoryAction, ApuestaDal>();
            services.AddScoped<IApuestaDetalleRepositoryAction, ApuestaDetalleDal>();
        }
     }
}

