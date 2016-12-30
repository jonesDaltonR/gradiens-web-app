using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradiens.Models
{
    // Seating Reservation object that is holds information for the SEATING_RES table
    public class SeatingResModels
    {
        [Required]
        [Display(Name = "Seating Reserveration ID")]
        public long SEATING_RES_ID { get; set; }

        [Required]
        [Display(Name = "Reserved Seat")]
        public string SEATING_RES_SEAT { get; set; }

        [Required]
        [Display(Name = "Reservation Cost")]
        public double SEATING_RES_COST { get; set; }

        [Required]
        [Display(Name = "Seating Capacity")]
        public int SEATING_RES_CAPACITY { get; set; }

        [Required]
        [Display(Name = "Arrival Date")]
        public DateTime SEATING_RES_ARRIVE_DATE { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime SEATING_RES_DEPART_DATE { get; set; }
    }
}