namespace MountinWeatherContainer.App.Core.Commands
{
    using MountinWeatherContainer.App.Core.Commands.Contracts;
    using MountinWeatherContainer.App.Core.Utilities;
    using MountinWeatherContainer.Services.Contracts;
    using System;

    public class AddWeatherStationCommand : ICommand
    {
        private readonly IWeatherStationService weatherStationService;

        public AddWeatherStationCommand(IWeatherStationService weatherStationService)
        {
            this.weatherStationService = weatherStationService;
        }

        public string Execute(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException(string.Format(AppConstants.InvalidCommandParams, AppConstants.RequiredAddWeatherStationParams));
            }

            string stationName = args[0];
            int altitude = int.Parse(args[1]);
            string mountainName = args[2];

            string lattitude = "n/a";
            string longitude = "n/a";

            if (args.Length == 5)
            {
                lattitude = args[3];
                longitude = args[4];
            }

            this.weatherStationService.Add(stationName, altitude, mountainName, lattitude, longitude);

            return string.Format(AppConstants.AddedWeatherStation, stationName);
        }
    }
}
