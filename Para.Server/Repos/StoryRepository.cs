using Microsoft.EntityFrameworkCore;
using Para.Server.Contracts;
using Para.Server.Data;
using Para.Shared;

namespace Para.Server.Repos
{
    public class StoryRepository<T> : IStoryRepository<T>
    {
        private readonly DataContext _context;

        public StoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AppUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }


        public void DeleteStory(T id)
        {
            ///TODO - CRUD
            throw new NotImplementedException();
        }

        public async Task<List<Stories>> GetAllStories() => await _context.UserStories.ToListAsync();


        public async Task<List<Stories>> GetUsersStory(string name)
        {
            //var appuser = await _context.AppUsers.Where(x => x.Username == id).FirstOrDefaultAsync();

            var userStories = await _context.UserStories.Where(x => x.User.Username == name).OrderByDescending(x => x.Time).Include(x => x.User).ToListAsync();

            return userStories;
        }

        public void InsertOrUpdate(Stories element)
        {
            
        }
    }
}
