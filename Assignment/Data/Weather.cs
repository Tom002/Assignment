using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data;

[Table("Weather")]
public class Weather
{
	[Column("Id")]
	public int Id { get; set; }

	[Column("Date")]
	public DateOnly Date { get; set; }

	[Column("Temperature")]
	public int Temperature { get; set; }

	[Column("CityName")]
	public required string CityName { get; set; }

	[Column("Summary")]
	public required string Summary { get; set; }
}
