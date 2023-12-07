using Microsoft.EntityFrameworkCore;
using PruebaDesarrollo.HumanResources.Application.Internal.Services;
using PruebaDesarrollo.HumanResources.Domain.Repositories;
using PruebaDesarrollo.HumanResources.Domain.Services;
using PruebaDesarrollo.HumanResources.Infrastructure.Repositories;
using PruebaDesarrollo.Shared.Domain.Repositories;
using PruebaDesarrollo.Shared.Infrastructure.Configuration;
using PruebaDesarrollo.Shared.Infrastructure.Repositories;

namespace PruebaDesarrollo
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

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepository>();
            builder.Services.AddScoped<ITrabajadorCommandService, TrabajadorCommandService>();
            builder.Services.AddScoped<ITrabajadorQueryService, TrabajadorQueryService>();
            builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
            builder.Services.AddScoped<IDistritoRepository, DistritoRepository>();
            builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                context?.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Use CORS middleware
            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}