using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Gradien.Models
{
    public class Hotels:GDbContext
    {


        [Key]
        [Required]
        [Display(Name = "Hotel ID")]
        public int HOTEL_ID { get; set; }

        [Required]
        [Display(Name = "Hotel Name")]
        public string HOTEL_NAME { get; set; }

        [Required]
        [Display(Name = "Hotel State")]
        public string HOTEL_STATE { get; set; }

        [Required]
        [Display(Name = "Hotel City")]
        public string HOTEL_CITY { get; set; }

        [Display(Name = "Hotel Image")]
        public string HOTEL_IMAGE { get; set; }

    }
}