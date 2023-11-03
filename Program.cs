using Microsoft.EntityFrameworkCore;
using CarApi.Context;
using CarApi.Repositories;
using CarApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarDbContext>(opt =>
    opt.UseSqlServer($"Server=LAPTOP-O9JU9206;Database=carDB;Trusted_Connection=yes;encrypt=false;"));

// Add services to the container.
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<ICarsService, CarsService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
