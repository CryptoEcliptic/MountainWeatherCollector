namespace MountinWeatherContainer.Services.Contracts
{
    public interface IWeatherParameterService
    {
        void Add(string weatherStationName, double temperature, double? windSpeed, double? airPressure, double? humidity, double? realFeeling, int? freezingLevel);

    }
}
