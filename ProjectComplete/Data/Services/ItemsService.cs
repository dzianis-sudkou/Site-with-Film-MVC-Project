using Microsoft.EntityFrameworkCore;
using ProjectComplete.Data.Base;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public class ItemsService : EntityBaseRepository<Item>, IItemsService
    {
        private readonly AppDbContext _context;
        public ItemsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Item GetItemById(int id)
        {
            var itemDetails = _context.Items
                .Include(c => c.Collection)
                .FirstOrDefault(n => n.Id == id);
            return itemDetails;
        }
        
        public IEnumerable<Item> GetAllById(int id)
        {
            var items = _context.Items
                .Where(c => c.CollectionId == id)
                .Include(c => c.Collection)
                .ToList();
            return items;
        }
    }
}
