using Para.Shared;

namespace Para.Server.Contracts
{
    public interface IRepository<T>
    {
        public User AppUser(int email);
        public T Get(int id);
        public IEnumerable<T> GetAll();
        public void InsertOrUpdate(T element);
        public bool UserExists(string email);
    }
}
