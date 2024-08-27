using FinanceTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Catergory> Catergories { get; set; }

        //TODO: Fix the bug where the Data Source won't use relative pathing
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=E:\Projects\FinanceTracker\app.db");
        }

        //Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
            );

            modelBuilder.Entity<Catergory>().HasData(
                new Catergory { Id = 1, Name = "Food" },
                new Catergory { Id = 2, Name = "Transport" },
                new Catergory { Id = 3, Name = "Entertainment" },
                new Catergory { Id = 4, Name = "Utilities" },
                new Catergory { Id = 5, Name = "Rent" },
                new Catergory { Id = 6, Name = "Other" }
            );

        }
    }

}
