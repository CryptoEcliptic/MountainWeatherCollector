﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MountinWeatherContainer.Data;

namespace MountinWeatherContainer.Data.Migrations
{
    [DbContext(typeof(MountainWeatherContext))]
    partial class MountainWeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MountinWeatherContainer.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MountinWeatherContainer.Models.Mountain", b =>
                {
                    b.Property<int>("MountainId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("MountainId");

                    b.HasIndex("CountryId");

                    b.ToTable("Mountains");
                });

            modelBuilder.Entity("MountinWeatherContainer.Models.WeatherParameter", b =>
                {
                    b.Property<int>("WeatherParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("AirPressure");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("FreezingLevelInMeters");

                    b.Property<double?>("Humidity");

                    b.Property<double?>("RealFeelingCelsius");

                    b.Property<double>("TemperatureCelsius");

                    b.Property<int>("WeatherStationId");

                    b.Property<double?>("WindSpeed");

                    b.HasKey("WeatherParameterId");

                    b.HasIndex("WeatherStationId");

                    b.ToTable("WeatherParameters");
                });

            modelBuilder.Entity("MountinWeatherContainer.Models.WeatherStation", b =>
                {
                    b.Property<int>("WeatherStationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Altitude");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<int>("MountainId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("WeatherStationId");

                    b.HasIndex("MountainId");

                    b.ToTable("WeatherStations");
                });

            modelBuilder.Entity("MountinWeatherContainer.Models.Mountain", b =>
                {
                    b.HasOne("MountinWeatherContainer.Models.Country", "Country")
                        .WithMany("Mountains")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MountinWeatherContainer.Models.WeatherParameter", b =>
                {
                    b.HasOne("MountinWeatherContainer.Models.WeatherStation", "WeatherStation")
                        .WithMany("WeatherParameters")
                        .HasForeignKey("WeatherStationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MountinWeatherContainer.Models.WeatherStation", b =>
                {
                    b.HasOne("MountinWeatherContainer.Models.Mountain", "Mountain")
                        .WithMany("WeatherStations")
                        .HasForeignKey("MountainId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
