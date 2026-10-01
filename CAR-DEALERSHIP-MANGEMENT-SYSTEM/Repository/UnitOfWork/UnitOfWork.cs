using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.GenaricRepo;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IGenaricRepo<Category> category, IGenaricRepo<Customer> customer, IGenaricRepo<CustomerProfile> customerProfile, IGenaricRepo<Employee> employee, IGenaricRepo<Sale> sale, IGenaricRepo<Vehicle> vehicle)
        {
            _context = context;
            this.category = category;
            this.customer = customer;
            this.customerProfile = customerProfile;
            this.employee = employee;
            this.sale = sale;
            this.vehicle = vehicle;
        }

        public IGenaricRepo<Category> category { get; }
        public IGenaricRepo<Customer> customer { get; }
        public IGenaricRepo<CustomerProfile> customerProfile { get; }
        public IGenaricRepo<Employee> employee { get; }
        public IGenaricRepo<Sale> sale { get; }
        public IGenaricRepo<Vehicle> vehicle { get; }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
