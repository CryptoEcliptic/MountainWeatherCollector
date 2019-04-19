using Newtonsoft.Json;

namespace MountinWeatherContainer.Services.DTOs.ExportDtos
{
    public class WeatherStatisticDto
    {
        [JsonProperty("Date")]
        public string DateTime { get; set; }

        [JsonProperty("Temperature")]
        public double TemperatureCelsius { get; set; }

        [JsonProperty("Real Feeling")]
        public double? RealFeelingCelsius { get; set; }

        public double? WindSpeed { get; set; }

        public double? Humidity { get; set; }

        public double? AirPressure { get; set; }

        [JsonProperty("Freezing altitude")]
        public double? FreezingLevelInMeters { get; set; }

        public string WeatherStation { get; set; }
    }
}
