namespace MountinWeatherContainer.Services
{
    using MountinWeatherContainer.Data;
    using MountinWeatherContainer.Services.Contracts;
    using MountinWeatherContainer.Services.DTOs;
    using MountinWeatherContainer.Services.ServiceExceptionMessages;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class WeatherStationStatisticService : IWeatherStationStatisticService
    {
        private const string JsonPath = @"../../../../MountinWeatherContainer.Services/Exports/WeatherStatistics.json";
        private readonly MountainWeatherContext context;

        public WeatherStationStatisticService(MountainWeatherContext context)
        {
            this.context = context;
        }

        public string GetStatistic(string weatherStationName)
        {
            var weatherStation = this.context
                .WeatherStations
                .FirstOrDefault(x => x.Name == weatherStationName);

            if (weatherStation == null)
            {
                throw new ArgumentException(ServiceExceptionMessage.InvalidWeatherStation, weatherStationName);
            }

            var weatherData = this.context.WeatherParameters
                .Where(x => x.WeatherStation.Name == weatherStation.Name)
                .Select(x => new WeatherStatisticDto()
                {
                    WeatherStation = x.WeatherStation.Name,
                    DateTime = x.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    TemperatureCelsius = x.TemperatureCelsius,
                    RealFeelingCelsius = x.RealFeelingCelsius,
                    WindSpeed = x.WindSpeed,
                    Humidity = x.Humidity,
                    AirPressure = x.AirPressure,
                    FreezingLevelInMeters = x.FreezingLevelInMeters
                })
                .ToList();
            var result = JsonConvert.SerializeObject(weatherData, Formatting.Indented);

            File.WriteAllText(JsonPath, result.TrimEnd());
            return result;
        }
    }
}
