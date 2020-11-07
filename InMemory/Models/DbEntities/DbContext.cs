using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InMemory.Models.DbEntities {
    public class MyContext : DbContext {
        public MyContext (DbContextOptions<MyContext> options) : base (options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Customer> ().HasData (
                new Customer () { CustomerId = 1, FirstName = "Ho", LastName = "Jason", Address = "USA" },
                new Customer () { CustomerId = 2, FirstName = "Yo", LastName = "Man", Address = "TW" }
            );
        }
    }
}