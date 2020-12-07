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

        private InterdisciplinaryContext dataContext;

        public AdminController(InterdisciplinaryContext dbContext) {
            dataContext = dbContext;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin admin) {
            foreach (Admin dbAdmin in dataContext.Admins) {
                if (dbAdmin.Username == admin.Username && dbAdmin.Password == admin.Password) {
                    return View("Shows");
                }
            }

            return View();
        }

        public IActionResult Shows() {

            return View();
        }

    }
}




// Jes added this, might come in handy later on



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Interdisciplinary.Data;
//using Interdisciplinary.Models;



//namespace Interdisciplinary.Controllers
//{​​
// public class AdminsController : Controller
// {​​
// private readonly InterdisciplinaryContext _context;



// public AdminsController(InterdisciplinaryContext context)
// {​​
// _context = context;
// }​​



// // GET: Admins
// public async Task<IActionResult> Index()
// {​​
// return View(await _context.Admin.ToListAsync());
// }​​



// // GET: Admins/Details/5
// public async Task<IActionResult> Details(int? id)
// {​​
// if (id == null)
// {​​
// return NotFound();
// }​​



// var admin = await _context.Admin
// .FirstOrDefaultAsync(m => m.AdminId == id);
// if (admin == null)
// {​​
// return NotFound();
// }​​



// return View(admin);
// }​​



// // GET: Admins/Create
// public IActionResult Create()
// {​​
// return View();
// }​​



// // POST: Admins/Create
// // To protect from overposting attacks, enable the specific properties you want to bind to, for
// // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
// [HttpPost]
// [ValidateAntiForgeryToken]
// public async Task<IActionResult> Create([Bind("AdminId,Username,Password")] Admin admin)
// {​​
// if (ModelState.IsValid)
// {​​
// _context.Add(admin);
// await _context.SaveChangesAsync();
// return RedirectToAction(nameof(Index));
// }​​
// return View(admin);
// }​​



// // GET: Admins/Edit/5
// public async Task<IActionResult> Edit(int? id)
// {​​
// if (id == null)
// {​​
// return NotFound();
// }​​



// var admin = await _context.Admin.FindAsync(id);
// if (admin == null)
// {​​
// return NotFound();
// }​​
// return View(admin);
// }​​



// // POST: Admins/Edit/5
// // To protect from overposting attacks, enable the specific properties you want to bind to, for
// // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
// [HttpPost]
// [ValidateAntiForgeryToken]
// public async Task<IActionResult> Edit(int id, [Bind("AdminId,Username,Password")] Admin admin)
// {​​
// if (id != admin.AdminId)
// {​​
// return NotFound();
// }​​



// if (ModelState.IsValid)
// {​​
// try
// {​​
// _context.Update(admin);
// await _context.SaveChangesAsync();
// }​​
// catch (DbUpdateConcurrencyException)
// {​​
// if (!AdminExists(admin.AdminId))
// {​​
// return NotFound();
// }​​
// else
// {​​
// throw;
// }​​
// }​​
// return RedirectToAction(nameof(Index));
// }​​
// return View(admin);
// }​​



// // GET: Admins/Delete/5
// public async Task<IActionResult> Delete(int? id)
// {​​
// if (id == null)
// {​​
// return NotFound();
// }​​



// var admin = await _context.Admin
// .FirstOrDefaultAsync(m => m.AdminId == id);
// if (admin == null)
// {​​
// return NotFound();
// }​​



// return View(admin);
// }​​



// // POST: Admins/Delete/5
// [HttpPost, ActionName("Delete")]
// [ValidateAntiForgeryToken]
// public async Task<IActionResult> DeleteConfirmed(int id)
// {​​
// var admin = await _context.Admin.FindAsync(id);
// _context.Admin.Remove(admin);
// await _context.SaveChangesAsync();
// return RedirectToAction(nameof(Index));
// }​​



// private bool AdminExists(int id)
// {​​
// return _context.Admin.Any(e => e.AdminId == id);
// }​​
// }​​
//}​​