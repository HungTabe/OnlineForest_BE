using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineForestAPI.DTO;
using OnlineForestAPI.Interfaces;

namespace OnlineForestAPI.Controllers
{
    [Route("api/land-category")]
    [ApiController]
    public class LandCategoryController : ControllerBase
    {

        private readonly ILandCategoryService _landCategoryService;

        // Constructor injection của ILandCategoryService
        public LandCategoryController(ILandCategoryService landCategoryService)
        {
            _landCategoryService = landCategoryService;
        }

        [HttpPost("register-land-category-by-admin")]
        public async Task<IActionResult> RegisterLandCategory([FromBody] RegisterLandCategoryRequestDTO request)
        {
            // Validate input model
            if (request == null || string.IsNullOrEmpty(request.LandCategoryName) || request.MaxSlots <= 0 || request.LandPrice < 0)
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                // Call RegisterLandCategoryAsync
                var landCategory = await _landCategoryService.RegisterLandCategoryAsync(request.UserId, request.MaxSlots, request.LandPrice, request.LandCategoryName);
                
                return CreatedAtAction(nameof(RegisterLandCategory), new { id = landCategory.LandCategoryId }, landCategory);
            }
            catch (ArgumentException ex)
            {
                // User not allow exception
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-all-land-category")]
        public async Task<IActionResult> GetAllLandCategories()
        {
            try
            {
                var landCategories = await _landCategoryService.GetAllLandCategoriesAsync();

                return Ok(landCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
