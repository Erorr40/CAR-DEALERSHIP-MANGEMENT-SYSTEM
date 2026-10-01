using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(e => e.Name).IsUnique(true);
            modelBuilder.Entity<Vehicle>().HasIndex(e => e.VIN).IsUnique(true);
            modelBuilder.Entity<Customer>().HasIndex(e => e.Email).IsUnique(true);
            modelBuilder.Entity<Customer>().HasIndex(e => e.DriverLicenseNumber).IsUnique(true);
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique(true);
            modelBuilder.Entity<Vehicle>().Property(e => e.Price).HasPrecision(12, 2);
            modelBuilder.Entity<Sale>().Property(e => e.SalePrice).HasPrecision(12, 2);
            modelBuilder.Entity<Vehicle>().Property(e => e.Status).HasDefaultValue("Available");


            modelBuilder.Entity<Vehicle>()
                .HasOne(e => e.category)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Sale>()
                .HasOne(e => e.customer)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Sale>()
                .HasOne(e => e.employee)
                .WithMany(e => e.sales)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Vehicle>()
                .HasOne(e => e.sale)
                .WithOne(e => e.vehicle)
                .HasForeignKey<Vehicle>(e => e.SalesId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Customer>()
                .HasOne(e => e.customerProfile)
                .WithOne(e => e.customer)
                .HasForeignKey<Customer>(e => e.CustomerProfileId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Category>()
                .HasData(
                new Category { CategoryId = 1, Name = "Sedan", Description = "Comfortable passenger cars" },
                new Category { CategoryId = 2, Name = "SUV", Description = "Sport utility vehicles" },
                new Category { CategoryId = 3, Name = "Hatchback", Description = "Compact practical cars" }
                );

            modelBuilder.Entity<Vehicle>()
                .HasData(
                new Vehicle { VehicleId = 1, Make = "Toyota", Model = "Corolla", Year = 2024, Color = "White", Price = 650000, Mileage = 12000, VIN = "VIN00000000000001", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 1, SalesId = 1 },
                new Vehicle { VehicleId = 2, Make = "Hyundai", Model = "Elantra", Year = 2023, Color = "Black", Price = 590000, Mileage = 18000, VIN = "VIN00000000000002", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", SalesId = 2, CategoryId = 2 },
                new Vehicle { VehicleId = 3, Make = "KIA", Model = "Sportage", Year = 2024, Color = "Grey", Price = 980000, Mileage = 9000, VIN = "VIN00000000000003", FuelType = "Petrol", Transmission = "Automatic", Status = "Available", CategoryId = 3, SalesId = 3 }
                );

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { CustomerId = 1, FullName = "Ahmed Hassan", Email = "ahmed.hassan@example.com", Phone = "01010000001", DriverLicenseNumber = "DL100001", CustomerProfileId = 1 },
                new Customer { CustomerId = 2, FullName = "Mona Adel", Email = "mona.adel@example.com", Phone = "01010000002", DriverLicenseNumber = "DL100002", CustomerProfileId = 2 },
                new Customer { CustomerId = 3, FullName = "Omar Khaled", Email = "omar.khaled@example.com", Phone = "01010000003", DriverLicenseNumber = "DL100003", CustomerProfileId = 3 }
                );

            modelBuilder.Entity<CustomerProfile>()
                .HasData(
                new CustomerProfile { CustomerProfileId = 1, Address = "12 Nile St.", City = "Cairo", Nationality = "Egypt", DateOfBirth = new DateTime(1992, 3, 12) },
                new CustomerProfile { CustomerProfileId = 2, Address = "25 Tahrir St.", City = "Giza", Nationality = "Egypt", DateOfBirth = new DateTime(1995, 7, 24) },
                new CustomerProfile { CustomerProfileId = 3, Address = "18 El Nasr St.", City = "Cairo", Nationality = "Egypt", DateOfBirth = new DateTime(1988, 11, 5) }
                );

            modelBuilder.Entity<Employee>()
                .HasData(
                new Employee { EmployeeId = 1, FullName = "Mostafa Nabil", Position = "Sales Manager", Email = "mostafa.nabil@autodrive.com", Phone = "01020000001", HireDate = new DateTime(2021, 1, 10) },
                new Employee { EmployeeId = 2, FullName = "Aya Emad", Email = "aya.emad@autodrive.com", Position = "Sales Consultant", Phone = "01020000002", HireDate = new DateTime(2022, 4, 15) },
                new Employee { EmployeeId = 3, FullName = "Hassan Ali", Position = "Sales Consultant", Email = "hassan.ali@autodrive.com", Phone = "01020000003", HireDate = new DateTime(2023, 2, 20) }
                );

            modelBuilder.Entity<Sale>()
                .HasData(
                new Sale { SaleId = 1, SaleDate = new DateTime(2026, 8, 15), SalePrice = 1750000, PaymentMethod = "Bank Transfer", Notes = "Completed sale.", CustomerId = 1, EmployeeId = 1 },
                new Sale { SaleId = 2, SaleDate = new DateTime(2026, 8, 22), SalePrice = 1850000, PaymentMethod = "Bank Transfer", Notes = "Completed sale.", CustomerId = 2, EmployeeId = 2 },
                new Sale { SaleId = 3, SaleDate = new DateTime(2026, 9, 05), SalePrice = 510000, PaymentMethod = "Cash", Notes = "Completed sale.", CustomerId = 3, EmployeeId = 3 }
                );
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerProfile> customerProfiles { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
    }
}
