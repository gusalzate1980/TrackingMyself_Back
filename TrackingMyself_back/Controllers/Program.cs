using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Repository.Time;
using UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TrackingMyselfDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrackingMyselfDbContext")));

#region Domain services
builder.Services.AddTransient<IBudgetAppService, BudgetAppService>();
builder.Services.AddSingleton<ISingletonDomainAppService, SingletonDomainAppService>();
#endregion

#region infrastructure services
builder.Services.AddScoped<ITimeRepository, TimeRepository>();
#endregion 

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrackingMyself API v1");
        c.RoutePrefix = string.Empty; // para que abra en la raíz (https://localhost:5001/)
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
