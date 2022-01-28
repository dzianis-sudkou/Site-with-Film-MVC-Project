using ProjectComplete.Data.ViewModels;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface IItemsService
    {
        IEnumerable<Item> GetAll();
        Item GetItemById(int id);
        IEnumerable<Item> GetAllById(int id);
        Task AddAsync(NewItemsVM item);
        IEnumerable<Item> Filter(string searchString);
        Item Update(Item item);
        void Delete(int id);
    }
}
