namespace MountinWeatherContainer.Services.Contracts
{
    using MountinWeatherContainer.Models;

    public interface IWeatherStationService
    {
        void Add(string stationName, int altitude, string mountainName, string lattitude, string longitude);

        bool Exists(string stationName);

        WeatherStation FindByName(string name);
    }
}
