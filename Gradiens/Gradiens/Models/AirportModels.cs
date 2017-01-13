using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradiens.Models
{
    // Airport object that is holds information for the AIRPORT table
    public class AirportModels
    {
        [Required]
        [Display(Name = "Airport ID")]
        public long AIRPORT_ID { get; set; }

        [Required]
        [Display(Name = "Airport Location ID")]
        public long AIRPORT_LOCATION { get; set; }

        [Required]
        [Display(Name = "Airport Name")]
        public string AIRPORT_NAME { get; set; }
    }
}