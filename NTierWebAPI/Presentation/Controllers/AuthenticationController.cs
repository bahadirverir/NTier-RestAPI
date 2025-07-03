using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Abstract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICustomAuthenticationService _service;
        public AuthenticationController(ICustomAuthenticationService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        [ModelValidationFilter]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _service.RegisterUser(userForRegistrationDto);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("Login")]
        [ModelValidationFilter]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if(!await _service.ValidateUser(user))
            {
                return Unauthorized();
            }
            var tokenDto = await _service.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }

        [HttpPost("RefreshToken")]
        [ModelValidationFilter]
        [Authorize]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var username = User.Identity?.Name;
            if(username == null)
            {
                return BadRequest("Invalid user");
            }
            await _service.RevokeRefreshToken(username);
            return NoContent();
        }
    }
}