namespace MountinWeatherContainer.Services
{
    using Microsoft.EntityFrameworkCore;
    using MountinWeatherContainer.Data;
    using MountinWeatherContainer.Services.Contracts;

    public class DatabaseService : IDatabaseService
    {
        private readonly MountainWeatherContext context;

        public DatabaseService(MountainWeatherContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            this.context.Database.OpenConnection();
        }
    }
}
