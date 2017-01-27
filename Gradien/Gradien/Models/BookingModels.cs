using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gradien.Models
{
    public class BookingModels
    {
        // Primary Keys
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BOOKING_ID { get; set; }
        
        public long USER_ID { get; set; }


        // Hotel data
        [Display(Name = "Hotel Name")]
        public string HOTEL_NAME { get; set; }

        [Display(Name = "Hotel Address")]
        public string HOTEL_ADDRESS { get; set; }

        [Display(Name = "Hotel Cost")]
        [UIHint("Currency")]
        public decimal HOTEL_COST { get; set; }

        [Display(Name = "Check in")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // Only allow Dates
        public DateTime HOTEL_CHECK_IN { get; set; }

        [Display(Name = "Check Out")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // Only allow Dates
        public DateTime HOTEL_CHECK_OUT { get; set; }


        // Flight data
        [Display(Name = "Departing")]
        public string DEPARTING { get; set; }
        
        [Display(Name = "Returning")]
        public string RETURNING { get; set; }
        
        [Display(Name = "# of Adults")]
        public int NO_ADULTS { get; set; }
        
        [Display(Name = "# of Children")]
        public int NO_CHILDREN { get; set; }

    }
}