using CAR_DEALERSHIP_MANGEMENT_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.GenaricRepo
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _db;

        public GenaricRepo(AppDbContext context, DbSet<T> db)
        {
            _context = context;
            _db = db;
        }

        public void Create(T entity)
        {
            _db.Add(entity);
        }

        public void Delete(int id)
        {
            _db.Remove(_db.Find(id));
        }

        public IEnumerable<T> GetAll()
        {
            return _db.ToList();
        }

        public T GetById(int Id)
        {
            return _db.Find(Id);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
