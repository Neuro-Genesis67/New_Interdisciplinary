﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Interdisciplinary.Models {
    public class Show {

        public int    ShowId           { get; set; } // PK
        
        // ---------------------

        [Required]
        public string   Title            { get; set; }
        public int      AvailableTickets { get; set; }
        public int      Price            { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date             { get; set; }

        [Required]
        public string   ImageUrl         { get; set; }

        public Genre    Genre            { get; set; } // Navigation property
        public int      GenreId          { get; set; } // FK

        public Admin    Admin            { get; set; } // Navigation property
        public int      AdminId          { get; set; } // FK
    }
}
