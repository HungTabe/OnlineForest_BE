using OnlineForestAPI.Models;

namespace OnlineForestAPI.Interfaces
{
    public interface ILandService
    {
        Task<Land> RegisterLandAsync(int userId, int LandCategoryId, string LandSpecificName);
    }
}
