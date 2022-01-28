using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface ICommentService
    {
        Task AddAsync(string userid, int id, string data);
    }
}
