namespace MountinWeatherContainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Mountain
    {
        /// <summary>
        /// Ctor initializing collection of type WeatherStation
        /// </summary>
        public Mountain()
        {
            this.WeatherStations = new List<WeatherStation>();
        }

        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public int MountainId { get; set; }

        /// <summary>
        /// Mountain name with constraints about the length of the name
        /// </summary>
        [Required]
        [MinLength(4, ErrorMessage = "The length of the name should be at least 4 symbols")]
        [MaxLength(32, ErrorMessage = "The length of the name should not exceed 32 symbols")]
        public string Name { get; set; }

        /// <summary>
        /// Country where mountain is positioned. Relation with Country
        /// </summary>
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        /// <summary>
        /// Every mountain has different number of Weather stations
        /// </summary>
        public ICollection<WeatherStation> WeatherStations { get; set; }
    }
}
