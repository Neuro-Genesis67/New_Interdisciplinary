using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Interdisciplinary.Models {
    public class Admin {
        // Admins are hardcoded in the database

        public int    AdminId  { get; set; } // PK
                                             // ---------------------
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; } // Might use a type meant for passwords later on

        //public virtual ICollection<Show> Shows { get; set; } // Not sure if this is the way to go

        public Admin() { }

        public Admin(int adminId, string username, string password) {
            AdminId  = adminId;
            Username = username;
            Password = password;
        }
    }
}
