using Microsoft.AspNetCore.Identity;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CommentService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            _context = appDbContext;
            _userManager = userManager;
        }
        public async Task AddAsync(string userid, int id, string data)
        {
            
            var user = await _userManager.FindByIdAsync(userid);
            var comment = new Comment()
            {
                UserName = user.FullName,
                ItemId = id,
                value = data
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
