namespace MountinWeatherContainer.App.Core.Commands
{
    using MountinWeatherContainer.App.Core.Commands.Contracts;
    using MountinWeatherContainer.Services.Contracts;
    /// <summary>
    /// This command invokes service class giving weather data statistic about particular weather station.
    /// The output is in json format
    /// </summary>
    public class GetWeatherStatisticCommand : ICommand
    {
        private readonly IWeatherStationStatisticService weatherStatisticService;

        public GetWeatherStatisticCommand(IWeatherStationStatisticService weatherStatisticService)
        {
            this.weatherStatisticService = weatherStatisticService;
        }

        public string Execute(string[] args)
        {
            string weatherStationName = args[0];

            string result = this.weatherStatisticService.GetStatistic(weatherStationName);

            return result;
        }
    }
}
