namespace MountinWeatherContainer.App.Core.Utilities
{
    internal static class AppConstants
    {
        internal const string Suffix = "Command";
        internal const string InvalidCommandMessage = "Invalid command!";
        internal const string AddedCountry = "Succesfully added country {0}!";
        internal const string AddedMountain = "Succesfully added mountain {0}!";
        internal const string InvalidCommandParams = "Invalid input! The method should take {0} paramerets!";
        internal const int RequiredAddMountainParams = 2;
        internal const int RequiredAddWeatherStationParams = 3;
        internal const string AddedWeatherStation = "Succesfully added weather station {0}!";
        internal const int RequiredWeatherParameters = 7;
        internal const string AddedWeatherDataMessage = "Succesfully added weather data from {0} weather station!";
    }
}
