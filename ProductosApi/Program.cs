using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Products.Querys;
using Products.Infrastructure.Context;
using Products.Infrastructure.Extensions;
using System.Reflection;

try
{
	var builder = WebApplication.CreateBuilder(args);
	var configuration = builder.Configuration;

    // Add services to the container.

    builder.Services.AddDbContext<ApplicationContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("db"),
            x => x.MigrationsAssembly("Products.Api"));
    });

    builder.Services.AddAuthorization();
	builder.Services.AddDomainServices();
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
	builder.Services.AddMediatR(Assembly.Load("Products.Application"), typeof(Program).Assembly);
    

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
}
catch (Exception e)
{

	throw;
}
