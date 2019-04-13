namespace MountinWeatherContainer.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using MountinWeatherContainer.App.Core.Commands.Contracts;
    using MountinWeatherContainer.App.Core.Contracts;
    using MountinWeatherContainer.App.Core.Utilities;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string[] args, IServiceProvider provider)
        {
            string commandName = args[0];
            string[] arguments = args.Skip(1).ToArray();

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName + AppConstants.Suffix);

            if (type == null)
            {
                throw new ArgumentNullException(null, AppConstants.InvalidCommandMessage);
            }

            var constructor = type
                .GetConstructors()
                .FirstOrDefault();

            var constructorParameters = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var services = constructorParameters
                .Select(provider.GetService)
                .ToArray();

            var instance = (ICommand)Activator.CreateInstance(type, services);

            string result = instance.Execute(arguments);

            return result;
        }
    }
}
