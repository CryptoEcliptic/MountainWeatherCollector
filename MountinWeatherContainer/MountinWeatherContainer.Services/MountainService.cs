namespace MountinWeatherContainer.Services
{
    using MountinWeatherContainer.Data;
    using MountinWeatherContainer.Models;
    using MountinWeatherContainer.Services.Contracts;
    using MountinWeatherContainer.Services.ServiceExceptionMessages;
    using System;
    using System.Linq;

    public class MountainService : IMountainService
    {
        private readonly MountainWeatherContext context;

        public MountainService(MountainWeatherContext context)
        {
            this.context = context;
        }

        public void Add(string mountainName, string countryName)
        {
            bool isExist = Exists(mountainName);

            if (isExist)
            {
                throw new ArgumentException(String.Format(ServiceExceptionMessage.ExistingMountain, mountainName));
            }

            int countryId = this.context.Countries
                .Where(x => x.Name == countryName)
                .Select(x => x.CountryId)
                .FirstOrDefault();

            if (countryId == 0)
            {
                throw new ArgumentException(String.Format(ServiceExceptionMessage.InvalidMountainCountryMessage, countryName));
            }

            Mountain mountain = new Mountain()
            {
                Name = mountainName,
                CountryId = countryId
            };

            this.context.Mountains.Add(mountain);
            this.context.SaveChanges();
        }

        public bool Exists(string name)
        {
            bool isExist = this.context.Mountains.Any(x => x.Name == name);

            return isExist;
        }

        public Mountain FindByName(string name)
        {
            var mountain = this.context.Mountains
                .Where(x => x.Name == name)
                .FirstOrDefault();

            return mountain;
        }
    }
}
