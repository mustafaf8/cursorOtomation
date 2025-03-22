using System;
using System.Collections.Generic;

namespace SolarAutomation.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal FinalAmount { get; set; }
        public string SystemType { get; set; } = string.Empty; // Ev, Tarla, Çatı GES
        public double RequiredPower { get; set; } // kW cinsinden
        public List<QuoteItem> Items { get; set; } = new();
        public string Notes { get; set; } = string.Empty;
    }

    public class QuoteItem
    {
        public int Id { get; set; }
        public int QuoteId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
} 