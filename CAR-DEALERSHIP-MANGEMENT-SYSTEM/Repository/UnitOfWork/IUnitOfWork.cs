using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.CustomRepos;
using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.GenaricRepo;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICategoryRepo category{ get; }
        public IGenaricRepo<Customer> customer { get; }
        public IGenaricRepo<CustomerProfile> customerProfile { get; }
        public IGenaricRepo<Employee> employee { get; }
        public IGenaricRepo<Sale> sale { get; }
        public IGenaricRepo<Vehicle> vehicle { get; }
        public void save();

    }
}
