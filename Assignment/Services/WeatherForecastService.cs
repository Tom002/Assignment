using Assignment.Data;
using Assignment.Dto;
using Assignment.Exceptions;
using Assignment.Extensions;
using Assignment.Pagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Services
{
    public class WeatherForecastService : IWeatherForecastService
	{
		private readonly AppDb _appDb;
		private readonly IMapper _mapper;

		public WeatherForecastService(AppDb appDb, IMapper mapper)
		{
			_appDb = appDb;
			_mapper = mapper;
		}

		public async Task<List<WeatherForecastDto>> ListWeatherForecastsAsync(string cityName, PageRequest pageRequest)
		{
			// SQLite nem támogatja ezt a megoldást
			//var city = await _appDb.Cities
			//	.AsNoTracking()
			//	.Include(c => c.Weather
			//		.Where(w => w.Date >= pageRequest.From)
			//		.Where(w => w.Date <= pageRequest.To)
			//		.Skip((pageRequest.Page - 1) * pageRequest.PageSize)
			//		.Take(pageRequest.PageSize)
			//		.OrderByDescending(w => w.Date))
			//	.SingleOrDefaultAsync(c => c.Name == cityName) ?? throw new EntityNotFoundException();

			//return _mapper.Map<List<WeatherForecastDto>>(city.Weather);

			pageRequest.InitializeIntervalFilters();

			var city = await _appDb.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.Name == cityName)
				?? throw new EntityNotFoundException();

			return await _appDb.Weather
				.Where(w => w.CityName == cityName)
				.Where(w => w.Date >= pageRequest.From)
				.Where(w => w.Date <= pageRequest.To)
				.Skip((pageRequest.Page - 1) * pageRequest.PageSize)
				.Take(pageRequest.PageSize)
				.OrderByDescending(w => w.Date)
				.ProjectTo<WeatherForecastDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<List<CityDto>> SearchCitiesAsync(string? cityNamePrefix = default)
		{
			return await _appDb.Cities
				.Where(!string.IsNullOrEmpty(cityNamePrefix), c => c.Name.StartsWith(cityNamePrefix))
				.OrderBy(c => c.Name)
				.Take(5)
				.ProjectTo<CityDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}
	}
}
