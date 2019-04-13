namespace MountinWeatherContainer.App.Core.Commands
{
    using System;

    using MountinWeatherContainer.App.Core.Commands.Contracts;
    using MountinWeatherContainer.App.Core.Utilities;
    using MountinWeatherContainer.Services.Contracts;
  
    public class AddWeatherDataCommand : ICommand
    {
        private readonly IWeatherParameterService weatherParameterService;

        public AddWeatherDataCommand(IWeatherParameterService weatherParameterService)
        {
            this.weatherParameterService = weatherParameterService;
        }

        public string Execute(string[] args)
        {
            string weatherStationName = args[0];
            double temperature = double.Parse(args[1]);
            double? windSpeed = NumberParser.ToNullableDouble(args[2]);
            double? airPressure = NumberParser.ToNullableDouble(args[3]);
            double? humidity = NumberParser.ToNullableDouble(args[4]);
            double? realFeeling = NumberParser.ToNullableDouble(args[5]);
            int? freezingLevel = NumberParser.ToNullableInt(args[6]);

            if (args.Length < 7)
            {
                throw new ArgumentException(string.Format(AppConstants.InvalidCommandParams, AppConstants.RequiredWeatherParameters));
            }

            weatherParameterService.Add(
                weatherStationName,
                temperature,
                windSpeed,
                airPressure,
                humidity,
                realFeeling,
                freezingLevel);

            return string.Format(AppConstants.AddedWeatherDataMessage, weatherStationName);
        }  
    }
}
