using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradiens.Models
{
    // Bus Stop object that is holds information for the BUS_STOP table
    public class BusStopModels
    {
        [Required]
        [Display(Name = "Bus Stop ID")]
        public long BUS_STOP_ID { get; set; }

        [Required]
        [Display(Name = "Bus Stop Name")]
        public string BUS_STOP_NAME { get; set; }

        [Required]
        [Display(Name = "Bus Stop Location ID")]
        public long BUS_STOP_LOCATION { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}