using ProjectComplete.Models;

namespace ProjectComplete.Data.Services
{
    public class CollectionsService : ICollectionsService
    {
        private readonly AppDbContext _appDbContext;
        public CollectionsService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Collection collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collection> GetAll()
        {
            throw new NotImplementedException();
        }

        public Collection GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Collection Update(int id, Collection newCollection)
        {
            throw new NotImplementedException();
        }
    }
}
