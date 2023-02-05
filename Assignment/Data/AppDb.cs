using Microsoft.EntityFrameworkCore;

namespace Assignment.Data;

public class AppDb : DbContext
{
	public AppDb(DbContextOptions<AppDb> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDb).Assembly);
	}

	public DbSet<City> Cities { get; set; }
	public DbSet<Weather> Weather { get; set; }
}
