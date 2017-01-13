using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradiens.Models
{
    // Airplane object that is holds information for the AIRPLANE table
    public class AirplaneModels
    {
        [Required]
        [Display(Name = "Airplane ID")]
        public long AIRPLANE_ID { get; set; }

        [Required]
        [Display(Name = "Airline Company Name")]
        public string AIRPLANE_AIRLINE_COMPANY { get; set; }

        [Required]
        [Display(Name = "Airport ID")]
        public long AIRPORT_ID { get; set; }

        [Required]
        [Display(Name = "Seating ID")]
        public long SEATING_ID { get; set; }
    }
}