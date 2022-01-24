namespace ProjectComplete.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var result = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            _context.Set<T>().Remove(result);
            _context.SaveChanges();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        } 
        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();
        public T GetById(int id) => _context.Set<T>().FirstOrDefault(x => x.Id == id);

        public T Update(int id, T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return (entity);
        }
    }
}
