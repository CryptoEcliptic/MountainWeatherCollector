namespace MountinWeatherContainer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WeatherStation
    {
        /// <summary>
        /// Identificator
        /// </summary>
        /// 
        [Key]
        public int WeatherStationId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The length of the name should be at least 3 symbols")]
        [MaxLength(32, ErrorMessage = "The length of the name should not exceed 32 symbols")]
        public string Name { get; set; }

        /// <summary>
        /// Weather station altitude
        /// </summary>
        [Required]
        [Range(658, 6000, ErrorMessage = "The altitude should be in range 658-6000")]
        public int Altitude { get; set; }

        /// <summary>
        /// Geographic coordinates of the station - Latitude
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Geographic coordinates of the station - Longitude
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// Relation with Mountain class
        /// </summary>
        [ForeignKey("Mountain")]
        public int MountainId { get; set; }
        public Mountain Mountain { get; set; }

        /// <summary>
        /// Object collection of WeatherParameter class
        /// </summary>
        public ICollection<WeatherParameter> WeatherParameters { get; set; }
    }
}
