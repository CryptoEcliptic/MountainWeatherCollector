namespace MountinWeatherContainer.Services
{
    using MountinWeatherContainer.Data;
    using MountinWeatherContainer.Models;
    using MountinWeatherContainer.Services.Contracts;
    using MountinWeatherContainer.Services.ServiceExceptionMessages;
    using System;
    using System.Linq;

    public class WeatherParameterService : IWeatherParameterService
    {
        private readonly MountainWeatherContext context;

        public WeatherParameterService(MountainWeatherContext context)
        {
            this.context = context;
        }

        public void Add(string weatherStationName, double temperature, double? windSpeed, double? airPressure, double? humidity, double? realFeeling, int? freezingLevel)
        {
            int weatherStationId = context.WeatherStations
                .Where(x => x.Name == weatherStationName)
                .Select(x => x.WeatherStationId)
                .FirstOrDefault();

            if (weatherStationId == 0)
            {
                throw new ArgumentException(ServiceExceptionMessage.InvalidWeatherParameterStationMessage, weatherStationName);
            }

            WeatherParameter parameter = new WeatherParameter()
            {
                DateTime = DateTime.Now,
                TemperatureCelsius = temperature,
                RealFeelingCelsius = realFeeling,
                WindSpeed = windSpeed,
                Humidity = humidity,
                AirPressure = airPressure,
                FreezingLevelInMeters = freezingLevel,
                WeatherStationId = weatherStationId
            };

            context.WeatherParameters.Add(parameter);
            context.SaveChanges();
        }
    }
}
