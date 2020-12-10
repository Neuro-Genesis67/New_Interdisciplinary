using Interdisciplinary.Data;
using Interdisciplinary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interdisciplinary.Controllers {
    public class CatalogController : Controller {

        private InterdisciplinaryContext db;

        public CatalogController(InterdisciplinaryContext dbContext) { 
            db = dbContext;
            //AddGenresToShows();
        }

        //public void AddGenresToShows() {

        //    ICollection<Show> shows = db.Shows.ToList<Show>();
        //    // Go through all the shows we got from the database
        //    foreach (Show show in shows) {
        //        // get the shows genreId
        //        int genreId = show.GenreId; // *1*

        //        // Go through genres in the database and find the one with the genreId
        //        foreach(Genre genre in db.Genres.ToList()) {
        //            if (genre.GenreId == genreId) {
        //                show.Genre = genre;
        //            } else {
        //                // If genreId is not the same as the show's genreId -> do nothing
        //            }
        //        }
        //    }
        //}

        public async Task<IActionResult> Index(string sortOrder) {
            var shows = from show in db.Shows select show;
            
            switch (sortOrder) {
                case "genre":
                shows = shows.OrderBy(s => s.GenreId);
                break;

                case "price":
                shows = shows.OrderBy(s => s.Price);
                break;

                case "date":
                shows = shows.OrderBy(s => s.Date);
                break;
            }
            return View(await shows.AsNoTracking().ToListAsync());
        }

        // ----------- Buy Ticket -----------
        public IActionResult BuyTicketAsync(int? id) {
            Show show = db.Shows.Find(id);
            int tickets = show.AvailableTickets - 1;

            if (tickets >= 0) {
                db.Database.ExecuteSqlCommand("EXEC BuyTicket @ShowId = " + @id + ", @AvailableTickets = " + @tickets + ";");
            } else {
                // No more tickets to buy -> Do nothing
            }

            ICollection<Show> shows = db.Shows.ToList<Show>();
            return View("Index", shows);
        }
    }
}
