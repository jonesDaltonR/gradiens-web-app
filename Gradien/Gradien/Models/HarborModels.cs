using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Gradien.Models
{
    // Harbor object that is holds information for the HARBOR table
    public class HarborModels
    {
        [Required]
        [Display(Name = "Harbor ID")]
        public long HARBOR_ID { get; set; }

        [Required]
        [Display(Name = "Harbor Name")]
        public string HARBOR_NAME { get; set; }

        [Required]
        [Display(Name = "Harbor Location ID")]
        public long HARBOR_LOCATION { get; set; }

        public bool DELETE_STAT { get; set; }
    }
}