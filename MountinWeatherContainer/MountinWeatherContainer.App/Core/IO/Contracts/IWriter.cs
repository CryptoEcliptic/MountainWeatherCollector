namespace MountinWeatherContainer.App.Core.IO.Contracts
{
    interface IWriter
    {
        void WriteLine(string text);

        void Write(string text);
    }
}
