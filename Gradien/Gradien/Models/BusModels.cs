﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
{
    // Bus object that is holds information for the BUS table
    public class BusModels
    {
        [Required]
        [Display(Name = "Bus ID")]
        public long BUS_ID { get; set; }

        [Required]
        [Display(Name = "Bus Company Name")]
        public string BUS_COMPANY { get; set; }

        [Required]
        [Display(Name = "Bus Stop ID")]
        public long BUS_STOP_ID { get; set; }

        [Required]
        [Display(Name = "Seating ID")]
        public long SEATING_ID { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}