using Para.Shared;
using System.Net.Http;
using System.Text.Json;

namespace Para.Client.Services
{
    public class StoryService : IStoryService
    {
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _options;
        public StoryService(HttpClient http)
        {
            _http = http;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public event Action OnChange;
        public async Task<List<Stories>> GetUserStories(string id)
        {

            var response = await _http.GetAsync($"https://localhost:7267/api/Story/getuserstories/{id}" );
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var stories = JsonSerializer.Deserialize<List<Stories>>(content, _options);
            //StoriesChanged();
            return stories;
           
        }

        public async Task<List<Stories>> GetAllStories()
        {
            var response = await _http.GetAsync("https://localhost:7267/api/Story/getstories");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var stories = JsonSerializer.Deserialize<List<Stories>>(content, _options);
            return stories;
        }

        void StoriesChanged() => OnChange.Invoke();
    }
}
