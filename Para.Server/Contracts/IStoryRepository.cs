using Para.Shared;

namespace Para.Server.Contracts
{
    public interface IStoryRepository<T>
    {
        public Task<User> AppUser(int id);
        public Task<List<Stories>> GetUsersStory(string id);
        public Task<List<Stories>> GetAllStories();
        public void InsertOrUpdate(Stories element);
        public void DeleteStory(T id);
        
    }
}
