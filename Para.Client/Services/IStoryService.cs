using Para.Shared;

namespace Para.Client.Services
{
    public interface IStoryService
    {
        Task<List<Stories>> GetUserStories(string id);
        Task<List<Stories>> GetAllStories();
    }
}
