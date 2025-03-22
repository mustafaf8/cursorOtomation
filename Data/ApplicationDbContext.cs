using Microsoft.EntityFrameworkCore;
using SolarAutomation.Models;

namespace SolarAutomation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SolarAutomation.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Customer)
                .WithMany()
                .HasForeignKey(q => q.CustomerId);

            modelBuilder.Entity<QuoteItem>()
                .HasOne(qi => qi.Product)
                .WithMany()
                .HasForeignKey(qi => qi.ProductId);
        }
    }
} 