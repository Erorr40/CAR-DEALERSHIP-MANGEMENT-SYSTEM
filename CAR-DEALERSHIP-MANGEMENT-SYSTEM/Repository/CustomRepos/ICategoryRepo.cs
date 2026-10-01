using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.GenaricRepo;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.CustomRepos
{
    public interface ICategoryRepo : IGenaricRepo<Category>
    {
        public IEnumerable<Category> GetCategoryWithVehCount(int id);
    }
}
