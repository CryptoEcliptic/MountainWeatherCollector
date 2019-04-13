using System;

namespace MountinWeatherContainer.App.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string[] args, IServiceProvider provider);
    }
}
