using Application.IServices;
using Application.Services;
using VinsportWebAPI.WebServices;

namespace VinsportWebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            services.AddSingleton<IClaimsService, ClaimsService>();

            services.AddScoped<ISportTypeService, SportTypeService>();

            return services;
        }
    }
}
