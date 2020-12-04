using Interdisciplinary.Data;
using Interdisciplinary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interdisciplinary.Controllers {
    public class CatalogController : Controller {

        private InterdisciplinaryContext dataContext;

        public CatalogController(InterdisciplinaryContext dbContext) {
            dataContext = dbContext;
        }

        public IActionResult Index() {

            List<Show> shows = new List<Show>();
            foreach (Show dbShow in dataContext.Shows.ToList()) {
                shows.Add(dbShow);
            }

            ViewData["Shows"] = shows;
            return View();
        }

    }
}
