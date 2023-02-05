using Assignment.Dto;
using Assignment.Pagination;
using Assignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers;

public class WeatherController : ControllerBase
{
	private readonly IWeatherForecastService _weatherForecastService;

	public WeatherController(IWeatherForecastService weatherForecastService)
	{
		_weatherForecastService = weatherForecastService;
	}

	[HttpGet("cities/{cityName}/weather")]
	public Task<List<WeatherForecastDto>> ListWeatherForecastsAsync([FromRoute] string cityName, [FromQuery] PageRequest pageRequest) =>
		_weatherForecastService.ListWeatherForecastsAsync(cityName, pageRequest);

	[HttpGet("cities")]
	public Task<List<CityDto>> SearchCitiesAsync([FromQuery] string? cityNamePrefix = null) =>
		_weatherForecastService.SearchCitiesAsync(cityNamePrefix);
}
