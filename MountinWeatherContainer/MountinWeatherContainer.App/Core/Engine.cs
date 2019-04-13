namespace MountinWeatherContainer.App.Core
{
    using Microsoft.Extensions.DependencyInjection;
    using MountinWeatherContainer.App.Core.Contracts;
    using MountinWeatherContainer.App.Core.IO.Contracts;
    using MountinWeatherContainer.Services.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            IDatabaseService databaseInitializer = this.serviceProvider.GetService<IDatabaseService>();
            databaseInitializer.Initialize();

            ICommandInterpreter commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();
            IReader reader = this.serviceProvider.GetService<IReader>();
            IWriter writer = this.serviceProvider.GetService<IWriter>();

            while (true)
            {
                string[] inputArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string result = commandInterpreter.Read(inputArgs, this.serviceProvider);
                    writer.WriteLine(result);
                }
                catch (ArgumentNullException ane)
                {
                    writer.WriteLine(ane.Message);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
        }
    }
}
