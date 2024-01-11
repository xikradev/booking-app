using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Models;
using api.Domain.Interfaces;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _service;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IIdentityService service, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _service = service;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserRegisterResponse>> Register([FromBody] UserRegisterRequest userRequest) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.Register(userRequest);
            if (result.IsSuccess)
            {
                return Ok(result);
            }else if(result.Errors.Count > 0)
            {
                return BadRequest(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login([FromBody] UserLoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.UserLogin(loginRequest);
            if (result.Success)
            {

                return Ok(result);
            }
            return Unauthorized(result);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult> getProfile()
        {
            User user = _userManager.GetUserAsync(User).Result;
            if(user == null)
            {
                return NotFound("User Not Found.");
            }

            return Ok(new { Username = user.Fullname, Email = user.Email });
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            Response.Cookies.Delete(".AspNetCore.Identity.Application");

            return Ok(new { Message = "Successful logout." });
        }
    }
}
