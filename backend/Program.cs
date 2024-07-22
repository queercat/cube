using Autofac;
using backend.context;
using backend.services;
using backend.services.CubeService;
using Microsoft.EntityFrameworkCore;

const string connectionString = "Data Source=c:../database/cube.db;Version=3;";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureContainer<ServiceCollection>(sc =>
{
    sc.AddDbContext<CubeDbContext>(options => options.UseSqlite(connectionString));
    sc.AddScoped<ICubeService, CubeService>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();



