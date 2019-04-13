namespace MountinWeatherContainer.Services.Contracts
{
    using MountinWeatherContainer.Models;

    public interface IMountainService
    {
        void Add(string name, string countryName);

        bool Exists(string name);

        Mountain FindByName(string name);
    }
}
