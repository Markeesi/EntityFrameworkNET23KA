using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EntityFrameworkNET23KA.Models
{
    public partial class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        public MasterContext() { }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@"C:\\Users\\Markk\\source\\repos\\EntityFrameworkNET23KA\\EntityFrameworkNET23KA\\appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("MyConnection");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    Console.WriteLine("Connection string not found in appsettings.json.");
                    return;
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D82090B1B4");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
