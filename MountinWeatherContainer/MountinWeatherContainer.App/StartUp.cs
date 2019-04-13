namespace MountinWeatherContainer.App
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MountinWeatherContainer.App.Core;
    using MountinWeatherContainer.App.Core.Contracts;
    using MountinWeatherContainer.App.Core.IO;
    using MountinWeatherContainer.App.Core.IO.Contracts;
    using MountinWeatherContainer.Data;
    using MountinWeatherContainer.Services;
    using MountinWeatherContainer.Services.Contracts;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            IEngine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MountainWeatherContext>(x => x.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<IReader, Reader>();
            serviceCollection.AddTransient<IWriter, Writer>();

            serviceCollection.AddTransient<IDatabaseService, DatabaseService>();
            serviceCollection.AddTransient<ICountryService, CountryService>();
            serviceCollection.AddTransient<IMountainService, MountainService>();
            serviceCollection.AddTransient<IWeatherStationService, WeatherStationService>();
            serviceCollection.AddTransient<IWeatherParameterService, WeatherParameterService>();
            serviceCollection.AddTransient<IWeatherStationStatisticService, WeatherStationStatisticService>();

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            IServiceProvider provider = serviceCollection.BuildServiceProvider();
            return provider;
        }
    }
}
