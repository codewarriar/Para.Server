using Para.Shared;

namespace Para.Server.Contracts
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string passowrd);
        Task<bool> UserExists(string email);
    }
}
