using OnlineForestAPI.DTO;
using OnlineForestAPI.Models;
using System.Security.Claims;

namespace OnlineForestAPI.Interfaces
{
    public interface ITreeCategoryService
    {
        Task<TreeCategory> RegisterTreeCategoryAsync(RegisterTreeCategoryRequestDTO dto, ClaimsPrincipal user);
    }
}
