namespace MountinWeatherContainer.Services.ServiceExceptionMessages
{
    internal static class ServiceExceptionMessage
    {
        internal const string ExistingCountry = "Country with name {0} already exists in the database!";
        internal const string ExistingMountain = "Mountain with name {0} already exists in the database!";
        internal const string InvalidMountainCountryMessage = "No country with name {0} found in the database! Create country first!";
        internal const string ExistingWeatherStationMessage = "Weather station with name {0} already exists in the database!";
        internal const string InvalidWeatherStationCountryMessage = "No mountain with name {0} found in the database! Create mountain first!";

        internal const string InvalidWeatherParameterStationMessage = "No weather station with name {0} found in the database! Create weather station first!";

        internal const string InvalidWeatherStation = "No weather station with name: {0} found!";
    }
}
