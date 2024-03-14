using KYC360_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace KYC360_Assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Name> Names { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Entity> Entities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, AddressLine = "123 Park Street", City = "Kolkata", Country = "India", EntityId = "1" },
                new Address { Id = 2, AddressLine = "456 MG Road", City = "Mumbai", Country = "India", EntityId = "2" },
                new Address { Id = 3, AddressLine = "789 Lake Road", City = "Chennai", Country = "India", EntityId = "3" },
                new Address { Id = 4, AddressLine = "101 Hill Avenue", City = "Bangalore", Country = "India", EntityId = "4" },
                new Address { Id = 5, AddressLine = "222 River Side", City = "Hyderabad", Country = "India", EntityId = "5" }
            );

            modelBuilder.Entity<Date>().HasData(
                new Date { Id = 1, DateType = "Birth", DateValue = new DateTime(1990, 1, 1), EntityId = "1" },
                new Date { Id = 2, DateType = "Death", DateValue = new DateTime(2020, 12, 31), EntityId = "2" },
                new Date { Id = 3, DateType = "Birth", DateValue = new DateTime(1985, 5, 15), EntityId = "3" },
                new Date { Id = 4, DateType = "Death", DateValue = new DateTime(2010, 8, 20), EntityId = "4" },
                new Date { Id = 5, DateType = "Birth", DateValue = new DateTime(1978, 11, 30), EntityId = "5" }
            );

            modelBuilder.Entity<Name>().HasData(
                new Name { Id = 1, FirstName = "Ravi", MiddleName = "Kumar", Surname = "Singh", EntityId = "1" },
                new Name { Id = 2, FirstName = "Sneha", MiddleName = "Rani", Surname = "Gupta", EntityId = "2" },
                new Name { Id = 3, FirstName = "Amit", MiddleName = "Kumar", Surname = "Sharma", EntityId = "3" },
                new Name { Id = 4, FirstName = "Priya", MiddleName = "Devi", Surname = "Verma", EntityId = "4" },
                new Name { Id = 5, FirstName = "Vikram", MiddleName = "Singh", Surname = "Yadav", EntityId = "5" }
            );

            modelBuilder.Entity<Entity>().HasData(
                new Entity { Id = "1", Deceased = false, Gender = "Male" },
                new Entity { Id = "2", Deceased = true, Gender = "Female" },
                new Entity { Id = "3", Deceased = false, Gender = "Male" },
                new Entity { Id = "4", Deceased = true, Gender = "Female" },
                new Entity { Id = "5", Deceased = false, Gender = "Male" }
            );
        }
    }
}
