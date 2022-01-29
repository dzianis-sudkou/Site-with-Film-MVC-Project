using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface IAdminService
    {
        List<ApplicationUser> ToList();
        Task newAdminAsync(string id);
        void Block(int id);
        Task Delete(string id);
    }
}
