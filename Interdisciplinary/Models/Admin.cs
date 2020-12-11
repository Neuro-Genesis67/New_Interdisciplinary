using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Interdisciplinary.Models {
    public class Admin {

        public int    AdminId  { get; set; } // PK
        // ---------------------
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; } 
    }
}
