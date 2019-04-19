namespace MountinWeatherContainer.App.Core.Commands
{
    using MountinWeatherContainer.App.Core.Commands.Contracts;
    using MountinWeatherContainer.App.Core.Utilities;
    using MountinWeatherContainer.Services.Contracts;

    public class AddCountryCommand : ICommand
    {
        private readonly ICountryService countryService;

        public AddCountryCommand(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public string Execute(string[] args)
        {
            string countryName = args[0];

            this.countryService.Add(countryName);

            return string.Format(AppConstants.AddedCountry, countryName);

        }
    }
}
