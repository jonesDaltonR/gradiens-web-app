using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
{
    // Location object that is holds information for the LOCATION table
    public class LocationModels
    {
        [Required]
        [Display(Name = "Location ID")]
        public long LOCATION_ID { get; set; }

        [Required]
        [Display(Name = "City Name")]
        public string LOCATION_CITY_NAME { get; set; }

        [Required]
        [Display(Name = "Country Name")]
        public string LOCATION_COUNTRY_NAME { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string LOCATION_ADDRESS { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        // Allows a maximum of 1 decimal place
        [RegularExpression(@"^\d+(\.\d)?$", ErrorMessage = "Cannot have more than one decimal point value")]
        [Range(-180, 180)] // Limit valid input between -180 and 180
        public decimal LOCATION_LONGITUDE { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        // Allows a maximum of 1 decimal place
        [RegularExpression(@"^\d+(\.\d)?$", ErrorMessage = "Cannot have more than one decimal point value")]
        [Range(-90, 90)] // Limit valid input between -90 and 90
        public decimal LOCATION_LATITUDE { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}