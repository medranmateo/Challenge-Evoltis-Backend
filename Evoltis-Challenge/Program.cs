using Evoltis_Challenge.Infraestructure.Repositories;
using Evoltis_Challenge.Infraestructure.Services;
using Evoltis_Challenge.Models;
using Evoltis_Challenge.Models.Repositories;
using Evoltis_Challenge.Models.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
    builder => builder.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod()));


//Add context
builder.Services.AddDbContext<AppDbContext>(optiosn =>
{
    optiosn.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});

// Automapper
builder.Services.AddAutoMapper(typeof(Program));

// Add Services
builder.Services.AddScoped<IProductoService, ProductoService >();

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
