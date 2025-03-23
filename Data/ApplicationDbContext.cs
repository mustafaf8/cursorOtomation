// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using SolarAutomation.Models;

namespace SolarAutomation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=solarautomation.db");
        }

        // Add this method to ensure your model changes are reflected in the database
        public void MigrateDatabase()
        {
            Database.EnsureDeleted(); // This will delete the existing database
            Database.EnsureCreated(); // This will recreate it with the current model
        }
    }
}