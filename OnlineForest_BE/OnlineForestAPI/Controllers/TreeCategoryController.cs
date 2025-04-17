using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineForestAPI.DTO;
using OnlineForestAPI.Interfaces;

namespace OnlineForestAPI.Controllers
{
    [Route("api/tree-category")]
    [ApiController]
    public class TreeCategoryController : ControllerBase
    {
        private readonly ITreeCategoryService _treeCategoryService;

        public TreeCategoryController(ITreeCategoryService treeCategoryService)
        {
            _treeCategoryService = treeCategoryService;
        }

        [HttpPost("register-tree-category-by-admin")]
        [Authorize] // Yêu cầu người dùng phải đăng nhập
        public async Task<IActionResult> RegisterTreeCategory([FromBody] RegisterTreeCategoryRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name) || request.TreePrice < 0 || request.GrowthTime <= 0)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var category = await _treeCategoryService.RegisterTreeCategoryAsync(request, User);
                return CreatedAtAction(nameof(RegisterTreeCategory), new { id = category.TreeCategoryId }, category);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
