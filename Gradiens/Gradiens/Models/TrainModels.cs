using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradiens.Models
{
    // Train object that is holds information for the TRAIN table
    public class TrainModels
    {
        [Required]
        [Display(Name = "Train ID")]
        public long TRAIN_ID { get; set; }

        [Required]
        [Display(Name = "Train Company Name")]
        public string TRAIN_COMPANY { get; set; }

        [Required]
        [Display(Name = "Station ID")]
        public long STATION_ID { get; set; }

        [Required]
        [Display(Name = "Seating ID")]
        public long SEATING_ID { get; set; }
    }
}