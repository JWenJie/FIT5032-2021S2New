using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_2021S2New.Models
{
    public class BookEvent
    {
        [Required]
        public int Event_id { get; set; }
        public Event Event { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}