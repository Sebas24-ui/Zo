using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder; // Necesario para WebApplication
using Microsoft.Extensions.Configuration;
using System;
using Zo; // Asumo que ZoContext está en la carpeta Data
using Newtonsoft.Json;

namespace Zo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ZoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ZoContext") ?? throw new InvalidOperationException("Connection string 'ZoContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers().AddNewtonsoftJson(
                 options =>
                 options.SerializerSettings.ReferenceLoopHandling
                 = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );
<<<<<<< HEAD
=======
            //sdfsdfsd
>>>>>>> Cambio
            var app = builder.Build();

            // Configure the HTTP request pipeline.
           // if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
