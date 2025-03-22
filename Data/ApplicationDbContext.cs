using Microsoft.EntityFrameworkCore;
using SolarAutomation.Models;

namespace SolarAutomation.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SolarAutomation.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
} 