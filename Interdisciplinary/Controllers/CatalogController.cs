using Interdisciplinary.Data;
using Interdisciplinary.Models;
using Microsoft.AspNetCore.Mvc;
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
            ICollection<Show> shows = db.Shows.ToList<Show>();

            return View(shows);
        }

    }
}
