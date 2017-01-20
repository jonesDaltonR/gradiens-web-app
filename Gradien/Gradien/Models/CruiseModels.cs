using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
// Cruise object that is holds information for the CRUISE table
{
    public class CruiseModels
    {
        [Required]
        [Display(Name = "Cruise ID")]
        public long CRUISE_ID { get; set; }

        [Required]
        [Display(Name = "Cruise Name")]
        public string CRUISE_NAME { get; set; }

        [Required]
        [Display(Name = "Cruise Company Name")]
        public string CRUISE_COMPANY { get; set; }

        [Required]
        [Display(Name = "Harbor ID")]
        public long HARBOR_ID { get; set; }

        [Required]
        [Display(Name = "Seating ID")]
        public long SEATING_ID { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}