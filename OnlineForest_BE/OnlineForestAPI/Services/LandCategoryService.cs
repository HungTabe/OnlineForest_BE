using OnlineForestAPI.Data;
using OnlineForestAPI.Interfaces;
using OnlineForestAPI.Models;

namespace OnlineForestAPI.Services
{
    public class LandCategoryService : ILandCategoryService
    {
        private readonly ForestOnlineDbContext _context;

        public LandCategoryService(ForestOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<LandCategory> RegisterLandCategoryAsync(int userId, int MaxSlots, int LandPrice, string LandCategoryName)
        {
            // Check if the user has the right to register the soil type (depending on the application regulations, for example, the user needs to have an admin or another) right)
            var user = await _context.Users.FindAsync(userId);
            if (user.Role != "ADMIN")
            {
                throw new ArgumentException("User not allow to register new LandCategory.");
            }

            // Make LandCategory Object
            var landCategory = new LandCategory
            {
                Name = LandCategoryName,
                MaxSlots = MaxSlots,
                LandPrice = LandPrice
            };

            _context.LandCategories.Add(landCategory);
            await _context.SaveChangesAsync();

            return landCategory;
        }
    }
}
