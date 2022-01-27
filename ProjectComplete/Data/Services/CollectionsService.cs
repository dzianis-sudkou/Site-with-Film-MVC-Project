using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectComplete.Data.ViewModels;
using ProjectComplete.Models;
using System.Security.Claims;

namespace ProjectComplete.Data.Services
{
    public class CollectionsService : ICollectionsService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CollectionsService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            _context = appDbContext;
            _userManager = userManager;
        }
        public void Add(NewCollectionVM data)
        {
            var сollection = new Collection()
            {
                ImageUrl = data.ImageUrl,
                Name = data.Name,
                Theme = data.Theme,
                Description = data.Description,
                UserId = data.UserId
            };
            _context.Collections.Add(сollection);
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

        public IEnumerable<Collection> GetAllById(string id)
        {
            var collections = _context.Collections
                .Where(c => c.UserId == id)
                .Include(c => c.ApplicationUser)
                .ToList();
            return collections;
           
        }

        public Collection GetById(int id)
        {
            var result = _context.Collections.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Collection Update(Collection newCollection)
        {
            _context.Update(newCollection);
            _context.SaveChanges();
            return (newCollection);
        }
    }
}
