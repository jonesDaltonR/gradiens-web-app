using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
{
    // Hotel object that is holds information for the HOTEL table
    public class HotelModels
    {
        [Required]
        [Display(Name = "Hotel ID")]
        public long HOTEL_ID { get; set; }

        [Required]
        [Display(Name = "Location ID")]
        public long HOTEL_LOCATION_ID { get; set; }

        [Required]
        [Display(Name = "Hotel Name")]
        public string HOTEL_NAME { get; set; }

        [Required]
        [Display(Name = "Hotel Company Name")]
        public string HOTEL_COMPANY { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public int HOTEL_ROOM_NUMBER { get; set; }

        [Required]
        [Display(Name = "Check in Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // Only allow Dates
        public DateTime HOTEL_CHECK_IN_DATE { get; set; }

        [Required]
        [Display(Name = "Check out Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // Only allow Dates
        public DateTime HOTEL_CHECK_OUT_DATE { get; set; }

        [Required]
        [Display(Name = "Total")]
        [UIHint("Currency")] // Takes decimal values that are valid currency values
        public decimal COST { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}