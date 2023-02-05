using Assignment.Data;
using Assignment.Dto;
using Assignment.Extensions;
using Assignment.Pagination;
using Assignment.Serialization;
using Assignment.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json;

[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDb>(opts => opts.UseSqlite($"Data Source=app.db"));

builder.Services.AddAutoMapper(cfg =>
{
	cfg.AddProfile<CityMappingProfile>();
	cfg.AddProfile<WeatherMappingProfile>();
});

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
		options.JsonSerializerOptions.Converters.Add(new CustomDateOnlyConverter("yyyy-MM-dd"));
	});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
	opts.MapType<DateOnly>(() => new OpenApiSchema { Format = "date", Type = "string" });
	opts.MapType<TimeOnly>(() => new OpenApiSchema { Format = "time", Type = "string" });
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<PageRequest>, PageRequestValidator>();
builder.Services.AddAssignmentProblemDetails();

var app = builder.Build();

using( var scope = app.Services.CreateScope() )
	scope.ServiceProvider.GetRequiredService<AppDb>().Database.Migrate();

if( app.Environment.IsDevelopment() )
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseProblemDetails();

app.Run();
