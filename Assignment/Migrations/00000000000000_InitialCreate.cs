using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Cities",
				columns: table => new
				{
					Name = table.Column<string>(type: "TEXT", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Cities", x => x.Name);
				});

			migrationBuilder.CreateTable(
				name: "Weather",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
					Temperature = table.Column<int>(type: "INTEGER", nullable: false),
					CityName = table.Column<string>(type: "TEXT", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Weather", x => x.Id);
					table.ForeignKey(
						name: "FK_Weather_Cities_CityName",
						column: x => x.CityName,
						principalTable: "Cities",
						principalColumn: "Name",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.Sql("""
				insert into Cities(Name) values
				('Békéscsaba'),
				('Budapest'),
				('Debrecen'),
				('Dunaújváros'),
				('Eger'),
				('Érd'),
				('Győr'),
				('Hódmezővásárhely'),
				('Kaposvár'),
				('Kecskemét'),
				('Miskolc'),
				('Nagykanizsa'),
				('Nyíregyháza'),
				('Pécs'),
				('Salgótarján'),
				('Sopron'),
				('Szeged'),
				('Székesfehérvár'),
				('Szekszárd'),
				('Szolnok'),
				('Szombathely'),
				('Tatabánya'),
				('Veszprém'),
				('Zalaegerszeg');

				with recursive range(i) as
				(
					select 1 as i
					union all
					select i+1 as i1 from range
					where i1 < 100
				)
				insert into Weather(Date,Temperature,CityName)
				select date('2021-10-01', printf('+%d day', r.i)), random() % 20, c.Name
				from range r
				cross join Cities c
				""");

			migrationBuilder.CreateIndex(
				name: "IX_Weather_CityName",
				table: "Weather",
				column: "CityName");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Weather");

			migrationBuilder.DropTable(
				name: "Cities");
		}
	}
}
