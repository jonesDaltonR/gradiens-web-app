using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
{
    // Regular User object that is holds information for the REG_USER table
    public class RegUserModels
    {
        [Required]
        [Display(Name = "User ID")]
        public long REG_USER_ID { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string REG_USER_PAYMENT_METHOD { get; set; }

        [Required]
        [Display(Name = "Home Airport")]
        public string REG_USER_HOME_AIRPORT { get; set; }

        [Required]
        [Display(Name = "Seating Preference")]
        public string REG_USER_SEATING_PREFERENCE { get; set; }

        [Required]
        [Display(Name = "Location ID")]
        public long REG_USER_LOCATION_ID { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}