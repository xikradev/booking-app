using api.Dto.Request;
using api.Dto.Response;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _service;

        public AccountController(IIdentityService service)
        {
            _service = service;
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
                

                return Ok(new {result.Token});
            }
            return Unauthorized(result);
        }

        [HttpGet]
        public async Task<ActionResult> teste()
        {
            return Ok("teste");
        }
    }
}
