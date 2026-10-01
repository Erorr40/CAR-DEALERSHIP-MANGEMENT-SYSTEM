using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.GenaricRepo;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.CustomRepos
{
    public class CategoryRepo : GenaricRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context, DbSet<Category> db) : base(context, db)
        {
        }

        public IEnumerable<Category> GetCategoryWithVehCount(int id)
        {
            return _db.Select(e => new Category { CategoryId  CategoryId });
        }
    }
}
