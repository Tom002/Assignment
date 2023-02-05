using Assignment.Data;
using AutoMapper;

namespace Assignment.Dto
{
	public class CityMappingProfile : Profile
	{
		public CityMappingProfile()
		{
			CreateMap<City, CityDto>();
		}
	}
}
