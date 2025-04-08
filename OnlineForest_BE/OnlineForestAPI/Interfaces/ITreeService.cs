using OnlineForestAPI.Models;

namespace OnlineForestAPI.Interfaces
{
    public interface ITreeService
    {
        Task<Tree> RegisterPlanTreeAsync(int userId, int TreeCategoryId, int LandId);
        Task<Tree> ConfirmPlanTreeAsync(int TreeId, int userId, int LandId);

    }
}
