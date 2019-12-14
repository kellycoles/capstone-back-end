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
        // Make database tables singular
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer ");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<Service>().ToTable("Service");

            //seed database
            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            //Create a Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    CustomerId = 1,
                    UserId = user.Id,
                    FirstName = "Joe",
                    LastName = "Smith",
                    StreetAddress = "5314 Grassland Drive",
                    City = "Murfreesboro",
                    Email = "Joey@gmail.com",
                    PhoneNumber = "615-812-9307"
                },
                new Customer()
                {
                    CustomerId = 2,
                    UserId = user.Id,
                    FirstName = "Jenny",
                    LastName = "Stevens",
                    StreetAddress = "4331 Banks Street",
                    City = "Murfreesboro",
                    Email = "Jenny@gmail.com",
                    PhoneNumber = "555-867-5309"
                }
             );
            modelBuilder.Entity<Service>().HasData(
                new Service()
                {
                   ServiceId = 1,
                   UserId = user.Id,
                   Name = "Mow",
                   Description = " Mow includes mowing, weedeating and edging around concrete, flower beds and trees, and blowing the grass off of all concrete."

                },
                new Service()
                {
                    ServiceId = 2,
                    UserId = user.Id,
                    Name = "Hedge Trimming",
                    Description = "Hedge Trimming includes trimming hedges to the customer's specification, and removing all debris."

                }
            );
            modelBuilder.Entity<Job>().HasData(
                new Job()
                {
                    ServiceId = 1,
                    CustomerId = 1,
                    Cost = 50.00,
                    IsComplete = true,
                    Paid = true,
                    Notes = "There was a car parked on the grass. I could not mow that area."
                },

             ); 
        }

    }
}
