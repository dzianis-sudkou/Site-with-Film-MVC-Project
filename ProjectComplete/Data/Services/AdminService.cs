using Microsoft.AspNetCore.Identity;
using ProjectComplete.Data.Static;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public void Block(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string id)
        {
            var user  = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            _context.SaveChanges();
        }

        public async Task newAdminAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            _context.SaveChanges();
        }

        public List<ApplicationUser> ToList()
        {
            var data = _userManager.Users.ToList();
            return data;
        }
    }
}
