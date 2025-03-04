using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ModernCRM.Models;
using System;
using System.IO;
using System.Windows;

namespace ModernCRM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<CustomerAgent> CustomerAgents { get; set; }
        
        public ApplicationDbContext()
        {
        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                try
                {
                    string connectionString = "server=127.0.0.1;port=3306;database=moderncrm;user=root;password=;AllowZeroDateTime=True;ConvertZeroDateTime=True;";
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                }
                catch (Exception ex)
                {
                    // Veritabanı bağlantı hatası
                    Console.WriteLine($"Veritabanı bağlantı hatası: {ex.Message}");
                    
                    // Bağlantı olmasa bile uygulamanın çalışmasına izin ver
                    // In-memory kullanmak iyi bir alternatif olabilir, ancak şimdilik sadece hata loglanacak
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kullanılacak sabit tarihler
            var createdAt = new DateTime(2025, 1, 1);
            var transactionDate = new DateTime(2025, 2, 15);
            var hireDate = new DateTime(2024, 12, 1);

            // Seed Customer Data
            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                { 
                    Id = 1, 
                    Name = "Ali Yılmaz", 
                    Company = "ABC Ltd", 
                    Phone = "555-123-4567", 
                    Email = "ali@example.com", 
                    Address = "İstanbul",
                    CreatedAt = createdAt
                },
                new Customer 
                { 
                    Id = 2, 
                    Name = "Ayşe Demir", 
                    Company = "XYZ A.Ş.", 
                    Phone = "555-987-6543", 
                    Email = "ayse@example.com", 
                    Address = "Ankara",
                    CreatedAt = createdAt
                }
            );

            // Seed Transaction Data
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction 
                { 
                    Id = 1, 
                    CustomerId = 1, 
                    Amount = 1500.00m, 
                    Type = TransactionType.Income, 
                    Description = "Danışmanlık ücreti", 
                    Category = "Hizmet", 
                    PaymentMethod = "Banka Transferi",
                    Date = transactionDate
                },
                new Transaction 
                { 
                    Id = 2, 
                    CustomerId = 2, 
                    Amount = 750.50m, 
                    Type = TransactionType.Income, 
                    Description = "Yazılım satışı", 
                    Category = "Ürün", 
                    PaymentMethod = "Kredi Kartı",
                    Date = transactionDate
                },
                new Transaction 
                { 
                    Id = 3, 
                    Amount = 250.00m, 
                    Type = TransactionType.Expense, 
                    Description = "Kira gideri", 
                    Category = "Ofis", 
                    PaymentMethod = "Banka Transferi",
                    Date = transactionDate
                }
            );
            
            // Seed Agent Data
            modelBuilder.Entity<Agent>().HasData(
                new Agent 
                { 
                    Id = 1, 
                    Name = "Mehmet Yıldız", 
                    Department = "Satış", 
                    Position = "Satış Temsilcisi", 
                    Phone = "555-111-2233", 
                    Email = "mehmet@example.com",
                    HireDate = hireDate
                },
                new Agent 
                { 
                    Id = 2, 
                    Name = "Zeynep Kaya", 
                    Department = "Müşteri İlişkileri", 
                    Position = "Müşteri Temsilcisi", 
                    Phone = "555-444-5566", 
                    Email = "zeynep@example.com",
                    HireDate = hireDate
                }
            );
        }
    }
    
    // Migration oluşturmak için design-time factory
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            string connectionString = "server=127.0.0.1;port=3306;database=moderncrm;user=root;password=;AllowZeroDateTime=True;ConvertZeroDateTime=True;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
} 