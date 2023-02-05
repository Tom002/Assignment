using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Data;

[Table("Cities")]
public class City
{
	[Key]
	[Column("Name")]
	public required string Name { get; set; }

	public ICollection<Weather> Weather { get; } = new List<Weather>();
}
