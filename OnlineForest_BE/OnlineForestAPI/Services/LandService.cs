using OnlineForestAPI.Data;
using OnlineForestAPI.DTO;
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

        public async Task<LandDTO> RegisterLandAsync(int userId, int LandCategoryId, string LandSpecificName)
        {
            // 1. Check if the user exists in the database
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            // 2. Check if the type of land (landcategory) does not exist
            var landCategory = await _context.LandCategories.FindAsync(LandCategoryId);
            if (landCategory == null)
            {
                throw new ArgumentException("Land Category not found.");
            }


            // 3. Create new Land object
            var land = new Land
            {
                UserId = userId,
                LandSpecificName = LandSpecificName,
                LandCategoryId = LandCategoryId,
                LandCategory = landCategory,
                LastPlanted = DateTime.Now
            };

            // 4. Add Land object to the database
            _context.Lands.Add(land);
            await _context.SaveChangesAsync();

            // 5. Return a LandDto (Data Transfer Object)
            var landDTO = new LandDTO
            {
                LandId = land.LandId,
                UserId = land.UserId,
                LandSpecificName = land.LandSpecificName,
                LandCategoryId = land.LandCategoryId,
                LastPlanted = land.LastPlanted
            };

            return landDTO; // Return the DTO instead of the full Land object
        }
    }
}
