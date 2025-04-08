using OnlineForestAPI.Data;
using OnlineForestAPI.Interfaces;
using OnlineForestAPI.Models;

namespace OnlineForestAPI.Services
{
    public class LandService : ILandService
    {
        public readonly ForestOnlineDbContext _context;

        public LandService(ForestOnlineDbContext context)
        {
            _context = context;
        }

        public Task<Land> RegisterLandAsync(int userId, int LandCategoryId, string LandSpecificName)
        {
            throw new NotImplementedException();
        }
    }
}
