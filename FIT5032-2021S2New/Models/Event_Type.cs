using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_2021S2New.Models
{
    public class Event_Type
    {
        [Key]
        public int Event_type_id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Event_name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Prize { get; set; }

        [Required]
        public string Description { get; set; } 
    }
}