using Microsoft.EntityFrameworkCore;
using StudentManagementSystem2.Models;

namespace StudentManagementSystem2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }
        public DbSet<Student> Students { get; set; }
    }
}

// This class manages the connection between the app and the database.
// DbSet<Student> property represents the Students tables in the database.
