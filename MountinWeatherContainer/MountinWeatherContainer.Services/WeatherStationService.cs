namespace MountinWeatherContainer.Services
{
    using MountinWeatherContainer.Data;
    using MountinWeatherContainer.Models;
    using MountinWeatherContainer.Services.Contracts;
    using MountinWeatherContainer.Services.ServiceExceptionMessages;
    using System;
    using System.Linq;

    public class WeatherStationService : IWeatherStationService
    {
        private readonly MountainWeatherContext context;

        public WeatherStationService(MountainWeatherContext context)
        {
            this.context = context;
        }

        public void Add(string stationName, int altitude, string mountainName, string lattitude, string longitude)
        {
            bool isExist = Exists(stationName);

            if (isExist)
            {
                throw new ArgumentException(string.Format(ServiceExceptionMessage.ExistingWeatherStationMessage, stationName));
            }

            int mountainId = this.context.Mountains
                .Where(x => x.Name == mountainName)
                .Select(x => x.MountainId)
                .FirstOrDefault();

            if (mountainId == 0)
            {
                throw new ArgumentException(string.Format(ServiceExceptionMessage.InvalidWeatherStationCountryMessage, mountainName));
            }

            WeatherStation weatherStation = new WeatherStation()
            {
                Name = stationName,
                Altitude = altitude,
                MountainId = mountainId,
                Latitude = lattitude,
                Longitude = longitude
            };

            this.context.WeatherStations.Add(weatherStation);
            this.context.SaveChanges();
        }

        public bool Exists(string stationName)
        {
            bool isExist = this.context.WeatherStations.Any(x => x.Name == stationName);

            return isExist;
        }

        public WeatherStation FindByName(string name)
        {
            var weatherStation = this.context.WeatherStations
               .Where(x => x.Name == name)
               .FirstOrDefault();

            return weatherStation;
        }
    }
}
