using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface ICommentService
    {
        Task AddAsync(ApplicationUser user, int id, string data);
        IEnumerable<Comment> GetAll(int id);
    }
}
