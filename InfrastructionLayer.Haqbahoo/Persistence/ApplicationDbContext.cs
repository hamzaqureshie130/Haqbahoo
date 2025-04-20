using DomainLayer.Haqbahoo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace InfrastructionLayer.Haqbahoo.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Categories Table
        public DbSet<Category> Categories { get; set; }

        // Cars Table
        public DbSet<Car> Cars { get; set; }

        // Features Table (Dynamic Car Features)
        public DbSet<Feature> Features { get; set; }

        // CarFeature (Many-to-Many Relation Between Car and Features)
        public DbSet<CarFeature> CarFeatures { get; set; }

        // Gallery Table (For Car Images)
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<WorkShop> Workshop { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        // Inventory Tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }



    }
}
