using OnlineForestAPI.DTO;
using OnlineForestAPI.Models;

namespace OnlineForestAPI.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(string username, string password, string email);
        Task<LoginResponseDTO> LoginAsync(string email, string password);
    }
}
