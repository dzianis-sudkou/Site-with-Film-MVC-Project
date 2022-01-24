using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface IItemsService
    {
        //Получаем все item из базы данных
        IEnumerable<Item> GetAll();

        //Получение одного отдельного item по id
        Item GetById(int id);

        //Добавление данных в базу данных
        void Add(Item newItem);

        //Обновление элемента в базе данных
        Collection Update(int id, Collection newCollection);

        //Удаление из базы данных
        void Delete(int id);
    }
}
