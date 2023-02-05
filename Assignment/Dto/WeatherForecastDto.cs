
namespace Assignment.Dto;

public class WeatherForecastDto
{
	public DateOnly Date { get; set; }

	public int Temperature { get; set; }

	public required string Summary { get; set; }
}
