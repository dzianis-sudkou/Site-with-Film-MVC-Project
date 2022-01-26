using Microsoft.EntityFrameworkCore;
using ProjectComplete.Data.Base;
using ProjectComplete.Data.ViewModels;
using ProjectComplete.Models;
using System.Linq.Expressions;

namespace ProjectComplete.Data.Services
{
    public class ItemsService : IItemsService
    {
        private readonly AppDbContext _context;
        public ItemsService(AppDbContext context)
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

        public void Add(NewItemsVM data)
        {
            var newItem = new Item()
            {
                Name = data.Name,
                Description = data.Description,
                CollectionId = data.Id
            };
            _context.Items.Add(newItem);
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            var result = _context.Items.ToList();
            return result;
        }

        public IEnumerable<Item> Filter(string searchString)
        {
            var items = from m in _context.Items
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name!.Contains(searchString));
            }
            return items.ToList();
        }
    }
}
