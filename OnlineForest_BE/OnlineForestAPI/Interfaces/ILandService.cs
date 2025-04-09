using OnlineForestAPI.DTO;
using OnlineForestAPI.Models;

namespace OnlineForestAPI.Interfaces
{
    public interface ILandService
    {
        Task<LandDTO> RegisterLandAsync(int userId, int LandCategoryId, string LandSpecificName);
    }
}
