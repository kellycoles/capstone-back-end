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
using MowPro.Models.ViewModels;

namespace MowPro.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public JobsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize]
        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Job
                .Include(c => c.Customer)
                .Include(c => c.Service).Where(j => j.Customer.UserId == user.Id && j.IsComplete == false).OrderByDescending(d => d.Date);
           
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> ClosedJobs()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Job
                .Include(c => c.Customer)
                .Include(c => c.Service).Where(j => j.Customer.UserId == user.Id && j.IsComplete).OrderByDescending(d => d.Date);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var job = await _context.Job
             .Include(c => c.Customer)
             .Include(c => c.Service)

             .FirstOrDefaultAsync(m => m.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        //GET: Jobs/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var viewModel = new JobCreateViewModel()
            {
                Customers = await _context.Customer.Where(c => c.UserId == user.Id).ToListAsync(),
                Services = await _context.Service.Where(c => c.UserId == user.Id).ToListAsync()
            };
            return View(viewModel);
        }

        // POST: Jobs/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Job job)
        {
            ModelState.Remove("JobId");

            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Your job was successfully added!";

                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (id == null)
            {
                return NotFound();
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
       
            var job = await _context.Job

                .Include(c => c.Customer)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(c => c.JobId == id);
            if (job == null)
            {
                return NotFound();
            }
            var serviceSelectItems = await _context.Service.Where(s => s.UserId == user.Id).ToListAsync();
            ViewData["ServiceId"] = new SelectList(serviceSelectItems, "ServiceId", "Name",job.ServiceId);

            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }
          
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
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
            ViewData["ServiceId"] = new SelectList(_context.Job, "Id", "Name", job.ServiceId);

            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var job = await _context.Job
             .Include(c => c.Customer)
             .Include(c => c.Service)

             .FirstOrDefaultAsync(m => m.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

  
        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Job.FindAsync(id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.JobId == id);
        }
    }
}
