namespace MountinWeatherContainer.App.Core.Utilities
{
    internal static class NumberParser
    {
        internal static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        internal static double? ToNullableDouble(this string s)
        {
            double i;
            if (double.TryParse(s, out i))
            {
                return i;
            } 
            return null;
        }
    }
}
