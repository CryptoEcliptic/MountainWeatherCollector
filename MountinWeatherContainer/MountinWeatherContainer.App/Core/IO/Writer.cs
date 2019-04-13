namespace MountinWeatherContainer.App.Core.IO
{
    using MountinWeatherContainer.App.Core.IO.Contracts;
    using System;

    public class Writer : IWriter
    {
       
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
