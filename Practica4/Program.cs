using Microsoft.EntityFrameworkCore;
using Practica4.BLL.Services;
using Practica4.DAL.Data;
using Practica4.DAL.Reporistorie;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Register EF Core DbContext
builder.Services.AddDbContext<PracticaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dependency Injection - Repository

builder.Services.AddScoped<IEstudianteRepository,EstudianteRepositorie>();

//Dependency Injection - Services
builder.Services.AddScoped<IEstudianteService,EstudianteService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
