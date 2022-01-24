namespace ProjectComplete.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();

        //Получение одной отдельной коллекции 
        T GetById(int id);

        //Добавление данных в базу данных
        void Add(T entity);

        //Обновление элемента в базе данных
        T Update(int id, T entity);

        //Удаление из базы данных
        void Delete(int id);
    }
}
