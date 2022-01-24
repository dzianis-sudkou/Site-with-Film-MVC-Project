using ProjectComplete.Data.Base;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface IItemsService : IEntityBaseRepository<Item>
    {
        Item GetItemById(int id);
        IEnumerable<Item> GetAllById(int id);
    }
}
