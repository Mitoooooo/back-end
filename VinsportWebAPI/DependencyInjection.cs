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
            services.AddScoped<ITimeSlotService, TimeSlotService>();
            services.AddScoped<IFieldClusterService, FieldClusterService>();
            services.AddScoped<ISportFieldService, SportFieldService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IVnPayService, VnPayService>();

            return services;
        }
    }
}
