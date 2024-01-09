using api.Dto.Request;
using api.Dto.Response;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _service;
        private readonly UserManager<User> _userManager;

        public AccountController(IIdentityService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
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

                User user = _userManager.FindByEmailAsync(loginRequest.Email).Result;

                return Ok(new { Username = user.Fullname, Email = user.Email });

                Response.Cookies.Append("token", result.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });

                return Ok(new {Username = user.Fullname, Email = user.Email});
            }
            return Unauthorized(result);
        }

        [HttpGet("/profile")]
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
    }
}
