using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TARA.DATAENTRY.API.Contracts;
using TARA.DATAENTRY.API.Models.Users;

namespace TARA.DATAENTRY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager authManager;
        private readonly ILogger<AuthController> loger;

        public AuthController(IAuthManager authManager,ILogger<AuthController> loger)
        {
            this.authManager = authManager;
            this.loger = loger;
        }
        //api/Auth/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            loger.LogInformation($"Registration attempt for {registerUserDto.Email}");
            
                var errors = await authManager.Register(registerUserDto);
                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Ok();
           

        }
        //api/Auth/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            loger.LogInformation($"Login attempt for {loginDto}");
          
                var authResponse = await authManager.Login(loginDto);
                if (authResponse == null)
                {
                    return Unauthorized();
                }

                return Ok(authResponse);
          
                

        }
        //api/Auth/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto authResponseDto)
        {
            var authResponse = await authManager.VerifyRefreshToken(authResponseDto);
            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);

        }
        //api/Auth/getuserinfo
        [HttpGet]
        [Route("getuserinfo")]
        public IActionResult GetUserInfo()
        {
            // Access user information from the JWT
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = HttpContext.User.Identity.Name;

            // Your logic here...

            return Ok(new { UserId = userId, Username = username });
        }
    }
}
