namespace MountinWeatherContainer.Services.Contracts
{
    using MountinWeatherContainer.Models;

    public interface ICountryService
    {
        void Add(string name);

        bool Exists(string name);

        Country FindByName(string name);
    }
}
