namespace MountinWeatherContainer.Data
{
    using Microsoft.EntityFrameworkCore;
    using MountinWeatherContainer.Models;

    public class MountainWeatherContext : DbContext
    {
        public MountainWeatherContext()
        {

        }

        public MountainWeatherContext(DbContextOptions options)
             : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<WeatherStation> WeatherStations { get; set; }
        public DbSet<Mountain> Mountains { get; set; }
        public DbSet<WeatherParameter> WeatherParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
