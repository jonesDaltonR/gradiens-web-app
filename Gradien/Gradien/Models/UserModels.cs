using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradien.Models
{
    // User object that is holds information for the USER table
    public class UserModels
    {
        [Key]
        [Required]
        [Display(Name = "User ID")]
        public long USER_ID { get; set; }

        [Required]
        [StringLength(100)]
        [Index("USER_EMAIL", 1, IsUnique = true)]
        [Display(Name = "Email Address")]
        [EmailAddress] // Must be in a valid email format i.e. me@email.com
        public string USER_EMAIL { get; set; }

        [Required]
        [DataType(DataType.Password)] // Hides user input as it's typed
        [Display(Name = "Password")]
        public string USER_PASSWORD { get; set; }

        public string USER_PASSWORD_SALT { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string USER_FIRST_NAME { get; set; }

        [Display(Name = "Middle Name")]
        public string USER_MIDDLE_NAME { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string USER_LAST_NAME { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] // Only allow Dates
        public DateTime USER_DATE_OF_BIRTH { get; set; }

        [Display(Name = "Payment Method")]
        public string USER_PAYMENT_METHOD { get; set; }

        [Display(Name = "Home Airport")]
        public string USER_HOME_AIRPORT { get; set; }

        [Display(Name = "Admin Status")]
        public bool ADMIN_CONTROLS { get; set; }

        [Display(Name = "Deletion Status")]
        public bool DELETE_STAT { get; set; }
    }
}