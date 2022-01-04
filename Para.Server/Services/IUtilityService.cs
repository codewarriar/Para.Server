using Para.Shared;

namespace Para.Server.Services
{
    public interface IUtilityService
    {
        Task<User> GetUser();
    }
}
