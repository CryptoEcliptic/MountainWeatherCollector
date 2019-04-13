namespace MountinWeatherContainer.App.Core.Commands
{
    using MountinWeatherContainer.App.Core.Commands.Contracts;
    using MountinWeatherContainer.App.Core.Utilities;
    using MountinWeatherContainer.Services.Contracts;
    using System;

    public class AddMountainCommand : ICommand
    {
        private readonly IMountainService mountainService;

        public AddMountainCommand(IMountainService mountainService)
        {
            this.mountainService = mountainService;
        }

        public string Execute(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException(string.Format(AppConstants.InvalidCommandParams, AppConstants.RequiredAddMountainParams));
            }
            string mountainName = args[0];
            string countryName = args[1];

            this.mountainService.Add(mountainName, countryName);

            return string.Format(AppConstants.AddedMountain, mountainName);
        }
    }
}
