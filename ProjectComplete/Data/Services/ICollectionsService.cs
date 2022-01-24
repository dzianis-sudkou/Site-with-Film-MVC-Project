using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface ICollectionsService
    {
        //Получаем все коллекции из базы данных
        IEnumerable<Collection> GetAll();

        //Получение одной отдельной коллекции
        Collection GetById(int id);

        //Добавление данных в базу данных
        void Add(Collection collection);

        //Возращение обновлённой версии из базы данных
        Collection Update(int id, Collection newCollection);

        //Удаление из базы данных
        void Delete(int id);
    }
}
