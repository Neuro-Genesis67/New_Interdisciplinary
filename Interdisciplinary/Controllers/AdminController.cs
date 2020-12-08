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


        
        [HttpPost]
        public async Task<IActionResult> CreateShow([Bind("Title,AvailableTickets,Price,Date,ImageUrl,GenreId,AdminId")] Show show) {
            if (ModelState.IsValid) {
                db.Add(show);
                await db.SaveChangesAsync();
            }
        }

        public IActionResult Shows() {

            ICollection<Show> shows = db.Shows.ToList();
            return View("Shows", shows);
        }

        public IActionResult CreateShow() {

            ViewData["AdminId"] = new SelectList(db.Admins, "AdminId", "AdminId");
            ViewData["GenreId"] = new SelectList(db.Genres, "GenreId", "Title");

            return View("CreateShow");
        }

        // ----------- Update -----------
        public IActionResult UpdateShow(int? id) {
            ViewData["ShowId"] = id;

            foreach (Show show in db.Shows) {
                if (show.ShowId == id) {
                    ViewData["AdminId"] = new SelectList(db.Admins, "AdminId", "AdminId", show.AdminId);
                    ViewData["GenreId"] = new SelectList(db.Genres, "GenreId", "Title",   show.GenreId);

                    return View("UpdateShow", show);
                }
            }
            return View("Shows");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShow(int id, [Bind("Title,AvailableTickets,Price,Date,ImageUrl,GenreId,AdminId")] Show show) {
            show.ShowId = id;
            db.Update(show);
            await db.SaveChangesAsync();

            ICollection<Show> shows = db.Shows.ToList();
            return View("Shows", shows);
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
