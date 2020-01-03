using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MowPro.Data;
using MowPro.Models;

namespace MowPro.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public ServicesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        // GET: Services
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var user = await GetCurrentUserAsync();
            var services =_context.Service.OrderBy(n => n.Name).Where(s => s.IsDeleted == false).Include(p => p.User).Where(p => p.UserId == user.Id);
            if (!String.IsNullOrEmpty(searchString))
            {
               services = _context.Service.OrderBy(n => n.Name).Where(s => s.IsDeleted == false).Include(p => p.User).Where(p => p.UserId == user.Id).Where(n => n.Name.Contains(searchString));
            }  
            return View(await services.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Name,Description,UserId")] Service service)
        {
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                service.UserId = user.Id;
                _context.Add(service);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Your service was successfully added!";
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Name,Description,UserId")] Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    service.UserId = user.Id;
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Your service was successfully edited!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .FirstOrDefaultAsync(m => m.ServiceId == id);

   
            List<Job> jobs = _context.Job.Include(s => s.Service).ToList();
            List<Job> inComplete = new List<Job>();
            foreach (var j in jobs)
            {
                if (j.IsComplete==false && j.ServiceId == id)
                {
                    inComplete.Add(j);
                    ViewBag.count = inComplete.Count();
                }
            }

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Service.FindAsync(id);
            service.IsDeleted = true;
            _context.Service.Update(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }
        
        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.ServiceId == id);
        }
    }
}
