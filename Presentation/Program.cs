
using Business.Extensions;
using Business.MappingProfiles;
using Data.Contexts;
using Data.Repositories.Abstract.Product;
using Data.Repositories.Concrete.Product;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Presentation.Middlewares;
using System;

namespace Presentation
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
			builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

			// Auto Mapper
			builder.Services.AddAutoMapper(x =>
			{
				x.AddProfile<ProductMappingProfile>();
			});

			#region Repositories
			builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
			builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
			#endregion

			#region Services
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddApplicationExtensions();
			#endregion


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
			app.UseMiddleware<CustomExceptionMiddleware>();

			app.Run();
		}
	}
}
