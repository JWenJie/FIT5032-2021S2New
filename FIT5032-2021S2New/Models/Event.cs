using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FIT5032_2021S2New.Models
{
    public class Event
    {
        [Key]
        public int Event_id { get; set; }
        
        [Required]
        [ForeignKey("Store")]
        public int Store_id { get; set; }
        public Store Store { get; set; }

        [Required]
        [ForeignKey("Event_Type")]
        public int Event_type_id { get; set; }
        public Event_Type Event_Type { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0: dddd, dd MMM yyyy hh:mm tt}")]
        public DateTime Start_time { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0: dddd, dd MMM yyyy hh:mm tt}")]
        public DateTime End_time { get; set; }  
    }
}