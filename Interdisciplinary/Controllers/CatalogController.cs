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
        }

        public IActionResult Index() {

            //if (sortOrder == null) {
            //    return View("Index");
            //} else {

            //}
            ////sort list based on sortOrder

            ICollection<Show> shows = db.Shows.ToList<Show>();

            return View(shows);
        }

        // ----------- Buy Ticket -----------
        public IActionResult BuyTicketAsync(int? id) {
            
            // Get the show with that id
            Show show = db.Shows.Find(id);

            int tickets = show.AvailableTickets - 1;
            if (tickets >= 0) {
                // Use stored procedure
                db.Database.ExecuteSqlCommand("EXEC BuyTicket @ShowId = " + @id + ", @AvailableTickets = " + @tickets + ";");
            } else {
                // No more tickets to buy -> Do nothing
            }

            // Reload catalog page
            ICollection<Show> shows = db.Shows.ToList<Show>();
            return View("Index", shows);
        }

        //public IActionResult SortByGenre() {
        //    ICollection<Show> shows = db.Shows.ToList<Show>();

        //    return View(shows);
        //}

        //public async Task<IActionResult> Index(string sortOrder) {
        //    //sorting stuff here
        //}
    }
}
