using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interdisciplinary.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interdisciplinary.Models;



namespace Interdisciplinary.Controllers {
    public class AdminController : Controller {

        private InterdisciplinaryContext db;

        public AdminController(InterdisciplinaryContext dbContext) {
            db = dbContext;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin admin) {
            ICollection<Show> shows = db.Shows.ToList<Show>();

            foreach (Admin dbAdmin in db.Admins) {
                if (dbAdmin.Username == admin.Username && dbAdmin.Password == admin.Password) {
                  
                    return View("Shows", shows);
                }
            }
            return View();
        }
      
        // Validation code from Jes
        //if (ModelState.IsValid) {​​ // validation succeeded

        // return View("success", model);

        //}
        //else { // validation failed

        //return View(model);
        //}

    }
}
