using Application.IServices;
using VinsportWebAPI.WebServices;

namespace VinsportWebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            services.AddSingleton<IClaimsService, ClaimsService>();



            return services;
        }
    }
}
