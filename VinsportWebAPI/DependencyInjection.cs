using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VinsportWebAPI.WebServices;

namespace VinsportWebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddSingleton<IClaimsService, ClaimsService>();

            services.AddScoped<ISportTypeService, SportTypeService>();
            services.AddScoped<ITimeSlotService, TimeSlotService>();
            services.AddScoped<IFieldClusterService, FieldClusterService>();
            services.AddScoped<ISportFieldService, SportFieldService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IVnPayService, VnPayService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            return services;
        }
    }
}
