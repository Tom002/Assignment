using Assignment.Data;
using AutoMapper;

namespace Assignment.Dto
{
	public class WeatherMappingProfile : Profile
	{
		public WeatherMappingProfile()
		{
			CreateMap<Weather, WeatherForecastDto>();
		}
	}
}
