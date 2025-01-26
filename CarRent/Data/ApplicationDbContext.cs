using CarRent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CarRent.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Salary> Salaries{ get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Incident> Incidents{ get; set; }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)");
        }

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Salary>()
              .Property(s => s.Amount)
              .HasPrecision(18, 2);
        }

            modelBuilder.Entity<Salary>()
               .Property(s => s.Amount)
               .HasPrecision(18, 2);

            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Discount>()
                .Property(d => d.DiscountAmount)
                .HasPrecision(18, 2);

        }
        public DbSet<CarRent.Models.Incident> Incident_1 { get; set; } = default!;

    }
}
