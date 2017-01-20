using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
{
    // Reservation object that is holds information for the RESERVATION table
    public class ReservationModels
    {
        [Required]
        [Display(Name = "Reservation ID")]
        public long RESERVATION_ID { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public long REG_USER_ID { get; set; }

        [Required]
        [Display(Name = "Seating ID")]
        public long SEATING_ID { get; set; }

        [Required]
        [Display(Name = "Total")]
        [UIHint("Currency")] // Takes decimal values that are valid currency values
        public decimal RESERVATION_TOTAL { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // Only allow Dates
        public DateTime RESERVATION_START_DATE { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // Only allow Dates
        public DateTime RESERVATION_END_DATE { get; set; }
        
        [Display(Name = "Active reservation?")]
        public bool RESERVATION_ACTIVE { get; set; }

        public bool DELETE_STAT { get; set; }

    }
}