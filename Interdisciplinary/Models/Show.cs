using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interdisciplinary.Models {
    public class Show {

        public int    ShowId           { get; set; } // PK
        public string CreatedBy        { get; set; } // FK
        public int    GenreId          { get; set; } // FK
        // ---------------------
        public string Title            { get; set; }
        public string Genre            { get; set; }
        public int    AvailableTickets { get; set; }
        public int    Price            { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date   { get; set; }
        public string ImageUrl { get; set; }
      }
}
