using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SneakersStore.API.ExceptionHandling;
using SneakersStore.Application.Services;
using SneakersStore.Core.Abstractions;
using SneakersStore.DataAccess;
using SneakersStore.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Глобальная обработка исключений
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Сервисы
builder.Services.AddScoped<ISneakersService, SneakersService>();

// Репозитории
builder.Services.AddScoped<ISneakersRepository, SneakersRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});

builder.Services.AddDbContext<SneakersStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SneakersStoreDbContext)));
});

var app = builder.Build();

app.UseExceptionHandler();
app.UseCors("Frontend");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();