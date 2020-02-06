using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MowPro.Data;
using MowPro.Models;
using MowPro.Models.ViewModels;

namespace MowPro.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public CustomersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Customers
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var user = await GetCurrentUserAsync();
            var customers = _context.Customer.OrderBy(c => c.FirstName).Include(p => p.User).Where(p => p.UserId == user.Id);

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = _context.Customer.OrderBy(c => c.LastName).Include(p => p.User).Where(p => p.UserId == user.Id).Where
                    (c => c.FirstName.Contains(searchString) || c.LastName.Contains(searchString) || c.Email.Contains(searchString)
                    || c.PhoneNumber.Contains(searchString));
            }
            
            return View(await customers.ToListAsync());

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateViewModel model)
        {
            //This UserId is the property in Customers. We are ignoring for now because we dont want to add it to a new customer 
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Customer newCustomer = new Customer
                {
                    UserId = user.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Preferences = model.Preferences,
                    PhotoPath = uniqueFileName
                };
                _context.Add(newCustomer);
                await _context.SaveChangesAsync();

                return RedirectToAction("details", new { id = newCustomer.CustomerId });

            }
            return View(model);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            CustomerEditViewModel customerEditViewModel = new CustomerEditViewModel
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                StreetAddress = customer.StreetAddress,
                City = customer.City,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Preferences = customer.Preferences,
                ExistingPhotoPath = customer.PhotoPath
            };
            if (customer == null)
            {
                return NotFound();
            }
            return View(customerEditViewModel);
        }

        //POST: Customers/Edit/5
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerEditViewModel model)
        {
            //This UserId is the property in Customers. We are ignoring for now because we dont want to add it to a new customer 
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                Customer customer = await _context.Customer.FindAsync(model.id);
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.StreetAddress = model.StreetAddress;
                customer.City = model.City;
                customer.Email = model.Email;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Preferences = model.Preferences;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                      string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                           "images/houses", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    customer.PhotoPath = ProcessUploadedFile(model);
                }
                var user = await _userManager.GetUserAsync(HttpContext.User);
            
                _context.Update(customer);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Your customer was successfully edited!";

                //return RedirectToAction("index");
                return RedirectToAction(nameof(Details), new { id = customer.CustomerId.ToString() });
            }
            return View(model);
        }


        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }

        // method for image upload
        private string ProcessUploadedFile(CustomerCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/houses");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
