using ProjectComplete.Data.ViewModels;
using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public interface ICollectionsService 
    {
        public IEnumerable<Collection> GetAllById(string id);
        //Получаем все коллекции из базы данных
        IEnumerable<Collection> GetAll();

        //Получение одной отдельной коллекции
        Collection GetById(int id);

        //Добавление данных в базу данных
        void Add(NewCollectionVM data);

        //Обновление элемента в базе данных
        Collection Update(int id, Collection newCollection);

        //Удаление из базы данных
        void Delete(int id);
    }
}
