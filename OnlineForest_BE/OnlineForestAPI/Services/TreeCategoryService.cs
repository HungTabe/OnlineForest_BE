using OnlineForestAPI.Data;
using OnlineForestAPI.DTO;
using OnlineForestAPI.Interfaces;
using OnlineForestAPI.Models;
using System.Security.Claims;

namespace OnlineForestAPI.Services
{
    public class TreeCategoryService : ITreeCategoryService
    {
        private readonly ForestOnlineDbContext _context;

        public TreeCategoryService(ForestOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<TreeCategory> RegisterTreeCategoryAsync(RegisterTreeCategoryRequestDTO dto, ClaimsPrincipal user)
        {
            var role = user.FindFirst(ClaimTypes.Role)?.Value;

            if (role != "ADMIN")
            {
                throw new UnauthorizedAccessException("Only ADMIN can register tree categories.");
            }

            var treeCategory = new TreeCategory
            {
                Name = dto.Name,
                TreePrice = dto.TreePrice,
                GrowthTime = dto.GrowthTime
            };

            _context.TreeCategories.Add(treeCategory);
            await _context.SaveChangesAsync();

            return treeCategory;
        }
    }
}
