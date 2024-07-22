using Autofac;
using backend.context;
using backend.services;
using backend.services.CubeService;
using Microsoft.EntityFrameworkCore;

const string connectionString = "Data Source=../Database/cube.db;";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureContainer<ServiceCollection>(sc =>
{
    sc.AddDbContext<CubeDbContext>(options => options.UseSqlite(connectionString));
    sc.AddScoped<ICubeService, CubeService>();
    sc.AddControllers(); // Required for the builder to figure out all the dependencies for the controllers. Magic!
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Required for .NET to autodetect controllers that inherit ControllerBase. Little less so but still kinda magic!

app.Run();



