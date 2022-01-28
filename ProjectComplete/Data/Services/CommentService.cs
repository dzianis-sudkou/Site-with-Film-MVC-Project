using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync(ApplicationUser user, int id, string data)
        {
            var comment = new Comment()
            {
                UserName = user.FullName,
                ItemId = id,
                value = data
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll(int id)
        {
            var comments = _context.Comments
                .Where(c => c.ItemId == id)
                .Include(c => c.Item)
                .ToList();
            return comments;
        }
    }
}
