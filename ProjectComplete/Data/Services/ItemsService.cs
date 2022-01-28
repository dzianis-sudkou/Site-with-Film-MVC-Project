using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectComplete.Data.ViewModels;
using ProjectComplete.Migrations;
using ProjectComplete.Models;
using System.Linq.Expressions;

namespace ProjectComplete.Data.Services
{
    public class ItemsService : IItemsService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ItemsService(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public Item GetItemById(int id)
        {
            var result = _context.Items
                .Where(c => c.Id == id)
                .Include(x => x.Collection)    
                .FirstOrDefault(x => x.Id == id);
            return result;
        }
        
        public IEnumerable<Item> GetAllById(int id)
        {
            var items = _context.Items
                .Where(c => c.CollectionId == id)
                .Include(c => c.Collection)
                .ToList();
            return items;
        }

        public async Task AddAsync(NewItemsVM data)
        {
            var newItem = new Item()
            {
                Name = data.Name,
                Description = data.Description,
                CollectionId = data.Id
            };
            await _context.Items.AddAsync(newItem);
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

        public Item Update(Item item)
        {
            _context.Update(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var result = _context.Items.FirstOrDefault(x => x.Id == id);
            _context.Items.Remove(result);
            _context.SaveChanges();
        }
    }
}
