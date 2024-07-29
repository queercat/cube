using Autofac;
using backend.context;
using backend.Extensions;
using backend.services;
using backend.Services.AuthService;
using backend.services.CubeService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

const string connectionString = "Data Source=./Database/cube.db;";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend", Version = "v1" });
});

builder.Host.ConfigureContainer<ServiceCollection>(sc =>
{
    sc.AddDbContext<CubeDbContext>(options => options.UseSqlite(connectionString));
    sc.AddScoped<ICubeService, CubeService>();
    sc.AddScoped<IAuthService, AuthService>();
    sc.AddControllers(); // Required for the builder to figure out all the dependencies for the controllers. Magic!
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.SaveSwaggerJson(); // Extension method I pulled from https://stackoverflow.com/questions/73655243/net-6-0-how-to-generate-swagger-json-file-on-build-in-net-6-0
}

app.UseHttpsRedirection();
app.MapControllers(); // Required for .NET to autodetect controllers that inherit ControllerBase. Little less so but still kinda magic!

if (args.Contains("--generate-api")) return;

// Allow CORS for localhost on any port, used https://stackoverflow.com/questions/57530680/enable-cors-for-any-port-on-localhost

app.UseCors(policyBuilder =>
{
    {
        if (app.Environment.IsDevelopment())
        {
            policyBuilder
                .SetIsOriginAllowed(host => new Uri(host).Host == "localhost")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    }
});

app.Run("https://0.0.0.0:42069");



