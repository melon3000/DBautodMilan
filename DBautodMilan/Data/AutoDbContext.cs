using DBautodMilan.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DBautodMilan.Models
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CarService> CarServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AutoServiceDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Id as primary key (CarService.Id exists on the model)
            // Remove the composite key to match the CarService model that contains Id.
            modelBuilder.Entity<CarService>()
                .HasKey(cs => cs.Id);

            // relations
            modelBuilder.Entity<CarService>()
                .HasOne(cs => cs.Car)
                .WithMany(c => c.CarServices)
                .HasForeignKey(cs => cs.CarId);

            modelBuilder.Entity<CarService>()
                .HasOne(cs => cs.Service)
                .WithMany(s => s.CarServices)
                .HasForeignKey(cs => cs.ServiceId);
        }
    }
}
