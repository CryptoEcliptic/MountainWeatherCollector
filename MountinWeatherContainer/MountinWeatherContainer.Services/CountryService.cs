namespace MountinWeatherContainer.Services
{
    using MountinWeatherContainer.Data;
    using MountinWeatherContainer.Models;
    using MountinWeatherContainer.Services.Contracts;
    using MountinWeatherContainer.Services.ServiceExceptionMessages;
    using System;
    using System.Linq;

    public class CountryService : ICountryService
    {
        private readonly MountainWeatherContext context;
        
        public CountryService(MountainWeatherContext context)
        {
            this.context = context;
        }

        public void Add(string name)
        {
            bool isExist = Exists(name);

            if (isExist)
            {
                throw new ArgumentException(String.Format(ServiceExceptionMessage.ExistingCountry, name));
            }

            Country country = new Country()
            {
                Name = name
            };

            this.context.Countries.Add(country);
            this.context.SaveChanges();
        }

        public bool Exists(string name)
        {
            bool isExist = this.context.Countries.Any(x => x.Name == name);

            return isExist;
        }

        public Country FindByName(string name)
        {
            var country = this.context.Countries
                .Where(x => x.Name == name)
                .FirstOrDefault();

            return country;
        }
    }
}
