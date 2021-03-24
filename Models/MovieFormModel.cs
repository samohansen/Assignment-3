using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models
{
    public class MovieFormModel
    {
        [Required]
        public string Category { get; set; }
        [Required][Key]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }


        // Dropdown menu
        [Required]
        public string Rating { get; set; }

        // Optional below here:
        // True/False or yes/no
        public bool Edited { get; set; }


        public string Lentto { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
        
    } 
}
