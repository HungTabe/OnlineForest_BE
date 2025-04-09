using Microsoft.AspNetCore.Mvc;
using OnlineForestAPI.DTO;
using OnlineForestAPI.Interfaces;

namespace OnlineForestAPI.Controllers
{
    [Route("api/land")]
    [ApiController]
    public class LandController : ControllerBase
    {
        private readonly ILandService _landService;

        public LandController(ILandService landService)
        {
            _landService = landService;
        }

        // POST api/land/register
        [HttpPost("register-land")]
        public async Task<IActionResult> RegisterLand([FromBody] RegisterLandRequestDTO request)
        {
            // Validate the input model (you can add additional validation if needed)
            if (request == null || request.UserId <= 0 || request.LandCategoryId <= 0 || string.IsNullOrEmpty(request.LandSpecificName))
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                // Call RegisterLandAsync to register the land
                var land = await _landService.RegisterLandAsync(request.UserId, request.LandCategoryId, request.LandSpecificName);

                // Return the created Land object in the response
                return CreatedAtAction(nameof(RegisterLand), new { id = land.LandId }, land);
            }
            catch (ArgumentException ex)
            {
                // Handle cases where the User or LandCategory is not found
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Handle cases where there are no available slots in the LandCategory
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                return StatusCode(500, ex.Message);
            }
        }
    }
}
