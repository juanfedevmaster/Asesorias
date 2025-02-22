
using ExampleWebApi.BusinessLogic.Infraestructura.Options;
using ExampleWebApi.BusinessLogic.Models;
using ExampleWebApi.DataBaseAccess;
using ExampleWebApi.DataBaseAccess.Interfaces;

namespace ExampleWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<OpcionesDeConexion>(builder.Configuration.GetSection("OpcionesDeConexion"));
            builder.Services.Configure<Configuracion>(builder.Configuration.GetSection("Configuracion"));

            builder.Services.AddScoped<IManejoVehiculos, ManejoVehiculos>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
