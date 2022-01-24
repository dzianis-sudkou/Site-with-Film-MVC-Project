using Microsoft.EntityFrameworkCore;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public class CollectionsService : ICollectionsService 
    {
        private readonly AppDbContext _context;
        public CollectionsService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Add(Collection collection)
        {
            _context.Collections.Add(collection);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _context.Collections.FirstOrDefault(x => x.Id == id);
            _context.Collections.Remove(result);
            _context.SaveChanges();
        }

        public IEnumerable<Collection> GetAll()
        {
            var result = _context.Collections.ToList();
            return result;

        }

        public Collection GetById(int id)
        {
            var result = _context.Collections.FirstOrDefault(x =>x.Id == id);
            return result;
        }

        public Collection Update(int id, Collection newCollection)
        {
            _context.Update(newCollection);
            _context.SaveChanges();
            return (newCollection);
        }
    }
}
