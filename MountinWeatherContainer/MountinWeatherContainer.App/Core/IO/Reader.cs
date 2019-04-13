namespace MountinWeatherContainer.App.Core.IO
{
    using MountinWeatherContainer.App.Core.IO.Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
