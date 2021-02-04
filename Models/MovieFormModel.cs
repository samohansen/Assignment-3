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
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string year { get; set; }
        [Required]
        public string director { get; set; }


        // Dropdown menu
        [Required]
        public string rating { get; set; }

        // Optional below here:
        // True/False or yes/no
        public bool edited { get; set; }


        public string lentto { get; set; }

        [StringLength(25)]
        public string notes { get; set; }
        
    }
}
