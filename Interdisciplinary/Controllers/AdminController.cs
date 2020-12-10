using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interdisciplinary.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interdisciplinary.Models;
using Microsoft.AspNetCore.Http;

namespace Interdisciplinary.Controllers {
    public class AdminController : Controller {

        private InterdisciplinaryContext db;

        public AdminController(InterdisciplinaryContext dbContext) { db = dbContext; }


        // ----------- Login -----------
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin admin) {
            ICollection<Show> shows = db.Shows.ToList();

            foreach (Admin dbAdmin in db.Admins) {
                if (dbAdmin.Username == admin.Username && dbAdmin.Password == admin.Password) {
                    HttpContext.Session.SetInt32("AdminId", dbAdmin.AdminId);
                    return View("Shows", shows);
                }
            }
            return View();
        }


        // ----------- List of shows -----------
        public IActionResult Shows() {
            ICollection<Show> shows = db.Shows.ToList();
            return View("Shows", shows);
        }


        // ----------- Create -----------
        public IActionResult CreateShow() {
            ViewData["GenreId"] = new SelectList(db.Genres, "GenreId", "Title");
            return View("CreateShow");
        }

        [HttpPost]
        public async Task<IActionResult> CreateShow([Bind("Title,AvailableTickets,Price,Date,ImageUrl,GenreId")] Show show) {
            if (ModelState.IsValid) {
                show.AdminId = (int)HttpContext.Session.GetInt32("AdminId");
                db.Add(show);
                await db.SaveChangesAsync();
            }

            ICollection<Show> shows = db.Shows.ToList();
            return View("Shows", shows);
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
            ICollection<Show> shows = db.Shows.ToList();
            return View("Shows", shows);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShow(int id, [Bind("Title,AvailableTickets,Price,Date,ImageUrl,GenreId,AdminId")] Show show) {
            show.ShowId = id;
            db.Update(show);
            await db.SaveChangesAsync();

            ICollection<Show> shows = db.Shows.ToList();
            return View("Shows", shows);
        }


        // ----------- Delete -----------
        public async Task<IActionResult> DeleteShow(int? id) {

            Show show = await db.Shows.FindAsync(id);
            db.Shows.Remove(show);
            await db.SaveChangesAsync();

            ICollection<Show> shows = db.Shows.ToList();
            return View("Shows", shows);
        }
    }
}
