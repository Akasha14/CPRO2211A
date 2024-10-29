using Microsoft.EntityFrameworkCore;
using Assignment2_ContactManager.Models;

namespace Assignment2_ContactManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> Categories { get; set; }


        // Add Data to start with.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add Categories.
            modelBuilder.Entity<Category>().HasData(
                new Category { categoryId = 1, name = "Family" },
                new Category { categoryId = 2, name = "Friend" },
                new Category { categoryId = 3, name = "Work" },
                new Category { categoryId = 4, name = "Other" }
            );

            // Add Base Contacts.
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    contactId = 1,
                    firstName = "John",
                    lastName = "Doe",
                    phoneNumber = "123-456-7890",
                    email = "johnDoe@gmail.com",
                    categoryId = 1,
                    organization = "Tech Inc."
                },
                new Contact
                {
                    contactId = 2,
                    firstName = "Alex",
                    lastName = "Meyer",
                    phoneNumber = "345-678-9012",
                    email = "alexM@outlook.com",
                    categoryId = 2
                }
            );
        }
    }
}
