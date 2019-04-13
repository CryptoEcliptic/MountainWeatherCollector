namespace MountinWeatherContainer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        /// <summary>
        /// Ctor initializing collection of type Mountain
        /// </summary>
        public Country()
        {
            this.Mountains = new List<Mountain>();
        }

        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public int CountryId { get; set; }

        /// <summary>
        /// CountryName
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "The length of the name should be at least 3 symbols")]
        [MaxLength(50, ErrorMessage = "The length of the name should not exceed 50 symbols")]
        public string Name { get; set; }

        public ICollection<Mountain> Mountains { get; set; }
    }
}
