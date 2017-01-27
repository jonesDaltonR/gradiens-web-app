using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Gradien.Models
{
    // Admin object that is holds information for the ADMIN table
    public class AdminModels
    {
        [Key]
        [Required]
        [Display(Name = "Admin ID")]
        public long ADMIN_ID { get; set; }

        [Required]
        [Display(Name = "Active admin status")]
        public bool ADMIN_CONTROLS { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}