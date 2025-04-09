using OnlineForestAPI.Models;

namespace OnlineForestAPI.Interfaces
{
    public interface ILandCategoryService
    {
        Task<LandCategory> RegisterLandCategoryAsync(int userId, int MaxSlots, int LandPrice, string LandCategoryName);

    }
}
