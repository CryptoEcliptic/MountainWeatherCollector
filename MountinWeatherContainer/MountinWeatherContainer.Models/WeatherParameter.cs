namespace MountinWeatherContainer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WeatherParameter
    {
        /// <summary>
        /// Identificator
        /// </summary>
        [Key]
        public int WeatherParameterId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Acctual measured temperature in Celsius
        /// </summary>
        [Required]
        [Range(-52.00, 52.00, ErrorMessage = "The temperature should be in the range of -52 to +52 degrees Celsius")]
        public double TemperatureCelsius { get; set; }

        /// <summary>
        /// Wind chill factor in Celsius. Depends on humidity, wind and TemperatureCelsius. Nullable because some weather stations do not meassure such information
        /// </summary>
        [Range(-56.00, 56.00, ErrorMessage = "The temperature should be in the range of -56 to +56 degrees Celsius")]
        public double? RealFeelingCelsius { get; set; }

        /// <summary>
        /// Wind speed in km/h.
        /// </summary>

        [Range(0, 130, ErrorMessage = "The wind speed should be in the range of 0 to 130 kilometers per hour")]
        public double? WindSpeed { get; set; }

        /// <summary>
        /// Hummididy in percent. Nullable because some weather stations do not meassure such information
        /// </summary>
        [Range(0, 100, ErrorMessage = "The humidity should be in the range of 0 to 100 percent")]
        public double? Humidity { get; set; }

        /// <summary>
        /// Ambient pressure in Hecto Pascals. Nullable because some weather stations do not meassure such information
        /// </summary>
        public double? AirPressure { get; set; }

        /// <summary>
        /// Altitude above which the temp is considered to be bellow freezing point. Nullable because some weather stations do not meassure such information
        /// </summary>
        [Range(0, 6000, ErrorMessage = "The freezing level should be in the range of 0 to 6000 meters")]
        public int? FreezingLevelInMeters { get; set; }

        /// <summary>
        /// Relarion with WeatherStation class
        /// </summary>
        [ForeignKey(nameof(WeatherStation))]
        public int WeatherStationId { get; set; }
        public WeatherStation WeatherStation { get; set; }
    }
}
