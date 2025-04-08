using OnlineForestAPI.Models;

namespace OnlineForestAPI.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(string username, string password, string email);
        Task<User> LoginAsync(string username, string password);
    }
}
