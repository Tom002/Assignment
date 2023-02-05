﻿// <auto-generated />
using System;
using Assignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Migrations
{
	[DbContext(typeof(AppDb))]
	[Migration("00000000000000_InitialCreate")]
	partial class InitialCreate
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

			modelBuilder.Entity("Assignment.Data.City", b =>
				{
					b.Property<string>("Name")
						.HasColumnType("TEXT")
						.HasColumnName("Name");

					b.HasKey("Name");

					b.ToTable("Cities");
				});

			modelBuilder.Entity("Assignment.Data.Weather", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER")
						.HasColumnName("Id");

					b.Property<string>("CityName")
						.IsRequired()
						.HasColumnType("TEXT")
						.HasColumnName("CityName");

					b.Property<DateOnly>("Date")
						.HasColumnType("TEXT")
						.HasColumnName("Date");

					b.Property<int>("Temperature")
						.HasColumnType("INTEGER")
						.HasColumnName("Temperature");

					b.HasKey("Id");

					b.HasIndex("CityName");

					b.ToTable("Weather");
				});

			modelBuilder.Entity("Assignment.Data.Weather", b =>
				{
					b.HasOne("Assignment.Data.City", null)
						.WithMany("Weather")
						.HasForeignKey("CityName")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();
				});

			modelBuilder.Entity("Assignment.Data.City", b =>
				{
					b.Navigation("Weather");
				});
#pragma warning restore 612, 618
		}
	}
}