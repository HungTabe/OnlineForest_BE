using OnlineForestAPI.Data;
using OnlineForestAPI.Interfaces;
using OnlineForestAPI.Models;

namespace OnlineForestAPI.Services
{
    public class TreeService : ITreeService
    {

        private readonly ForestOnlineDbContext _context;

        public TreeService(ForestOnlineDbContext context)
        {
            _context = context;
        }

        public Task<Tree> ConfirmPlanTreeAsync(int TreeId, int userId, int LandId)
        {
            throw new NotImplementedException();
        }

        public Task<Tree> RegisterPlanTreeAsync(int userId, int TreeCategoryId, int LandId)
        {
            throw new NotImplementedException();
        }
    }
}
