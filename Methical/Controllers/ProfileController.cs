using Methical.Models;
using Methical.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Methical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private static IProfileService _profileService { get; set; }
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        [Route("generate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Profile))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Profile>> GenerateProfile([FromQuery] bool StableDiffusion, bool FromSpace = true)
        {
            Profile profile = await _profileService.GetProfileFromSpaceAsync(StableDiffusion);

            if (profile is null) return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            return Ok(profile);
        }
    }
}
