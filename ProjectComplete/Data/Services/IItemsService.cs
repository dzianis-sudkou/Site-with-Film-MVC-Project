using ProjectComplete.Data.Base;
using ProjectComplete.Data.ViewModels;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface IItemsService
    {
        IEnumerable<Item> GetAll();
        Item GetItemById(int id);
        IEnumerable<Item> GetAllById(int id);
        void Add(NewItemsVM item);

        IEnumerable<Item> Filter(string searchString);
    }
}
