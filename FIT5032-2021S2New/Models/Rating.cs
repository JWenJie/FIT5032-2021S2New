using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_2021S2New.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public int Store_id { get; set; }
        public Store Store { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rate { get; set; } = 0;
        public string Comment { get; set; }

    }
}