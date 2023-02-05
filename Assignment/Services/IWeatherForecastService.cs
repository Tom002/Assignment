using Assignment.Dto;
using Assignment.Pagination;

namespace Assignment.Services
{
	public interface IWeatherForecastService
	{
		public Task<List<WeatherForecastDto>> ListWeatherForecastsAsync(string cityName, PageRequest pageRequest);

		public Task<List<CityDto>> SearchCitiesAsync(string? cityNamePrefix = default);
	}
}
