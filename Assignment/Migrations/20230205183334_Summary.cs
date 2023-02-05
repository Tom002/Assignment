using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.Metrics;
using System;

#nullable disable

namespace Assignment.Migrations
{
    /// <inheritdoc />
    public partial class Summary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Weather",
                type: "TEXT",
			nullable: false,
			computedColumnSql: @"
			CASE
				WHEN Temperature < 10 
					THEN 'cool and calm'
				ELSE 
					'nice and warm'
			END");

		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Weather");
        }
    }
}
