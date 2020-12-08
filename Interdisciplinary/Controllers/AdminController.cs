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
            ICollection<Show> shows = db.Shows.ToList();

            foreach (Admin dbAdmin in db.Admins) {
                if (dbAdmin.Username == admin.Username && dbAdmin.Password == admin.Password) {
                    return View("Shows", shows);
                }
            }
            return View();
        }

        // POST: Show/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,Title,AvailableTickets,Price,Date,ImageUrl,GenreId,AdminId")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Add(show);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(db.Admins);
            ViewData["GenreId"] = new SelectList(db.Genres);
            return View(show);
        }

        public IActionResult CreateShow() {
            return View("CreateShow");
        }

        public IActionResult UpdateShow() {
            return View("UpdateShow");
            //< a asp - action = "UpdateShow" asp - route - id = "@show.ShowId" > Update </ a >
        }

        public IActionResult DeleteShow(Show show) {

            // Remove show from database

            // Return to updated list of shows
            return View("CreateShow");
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
