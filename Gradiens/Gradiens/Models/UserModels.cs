using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradiens.Models
{
    // User object that is holds information for the USER table
    public class UserModels
    {
        [Required]
        [Display(Name = "User ID")]
        public long USER_ID { get; set; }

        public string USER_USERNAME { get; set; }
        
        [Required]
        [DataType(DataType.Password)] // Hides user input as it's typed
        [Display(Name = "Password")]
        public string USER_PASSWORD { get; set; }

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

        [Required]
        [Display(Name = "Gender")]
        public string USER_GENDER { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress] // Must be in a valid email format i.e. me@email.com
        public string USER_EMAIL { get; set; }
    }
}