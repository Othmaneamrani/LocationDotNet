using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Mapper
{
    public static class AutoMapperConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VehiculeMapper));
            services.AddAutoMapper(typeof(DemandeMapper));
            services.AddAutoMapper(typeof(CompteMapper));
        }
    }
}
