using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MowPro.Models;

namespace MowPro.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<CustomerService> CustomerService { get; set; }
    }
}
