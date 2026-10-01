namespace CAR_DEALERSHIP_MANGEMENT_SYSTEM.Repository.GenaricRepo
{
    public interface IGenaricRepo<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(int Id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
