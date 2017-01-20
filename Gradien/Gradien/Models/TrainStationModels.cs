using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
{
    // Train Station object that is holds information for the TRAIN_STATION table
    public class TrainStationModels
    {
        [Required]
        [Display(Name = "Station ID")]
        public long STATION_ID { get; set; }

        [Required]
        [Display(Name = "Station Name")]
        public string STATION_NAME { get; set; }

        [Required]
        [Display(Name = "Station Location ID")]
        public long STATION_LOCATION { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}