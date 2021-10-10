using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_2021S2New.Models
{
    public class Store
    {
        [Key]
        public int Store_id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Store_name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Store_address { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public int Contact_number { get; set; }
    }
}