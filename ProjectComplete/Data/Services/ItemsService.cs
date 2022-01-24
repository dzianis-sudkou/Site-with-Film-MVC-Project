using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public class ItemsService : IItemsService
    {
        private readonly AppDbContext _context;
        public ItemsService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Add(Item newItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAll()
        {
            var result = _context.Items.ToList();
            return result;
        }

        public Item GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Collection Update(int id, Collection newCollection)
        {
            throw new NotImplementedException();
        }
    }
}
