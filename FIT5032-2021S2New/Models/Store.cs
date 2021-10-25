using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MaxLength(100)]
        public string Store_address { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Not a valid phone number")]
        public int Contact_number { get; set; }
        
        [NotMapped]
        [Display(Name ="Rating")]
        public decimal AvgRating { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}