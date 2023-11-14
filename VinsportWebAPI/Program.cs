using Application;
using Infrastructure;
using Infrastructure.MapperConfiguration;
using Microsoft.AspNetCore.OData;
using VinsportWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(10));

builder.Services.AddAutoMapper(typeof(MapperConfiguration));
var configuration = builder.Configuration.Get<AppConfiguration>();
builder.Services.AddSingleton(configuration);
builder.Services.AddControllers().AddOData(options =>
{
    options.EnableQueryFeatures(maxTopValue: null);
    // Disable attribute routing
    options.AddRouteComponents(routePrefix: "odata", ODataModel.GetEdmModel());
});
builder.Services.AddInfrastructuresService(configuration!.DatabaseConnection);
builder.Services.AddAPIServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();