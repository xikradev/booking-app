using api.Dto;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController :ControllerBase
    {
        private readonly IAuthenticateService _authenticate;

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "As senhas não conferem.");
                return BadRequest(ModelState);
            }

            var result = await _authenticate.RegisterUser(model.UserName, model.Email, model.Password);
            if (result)
            {
                return Ok($"Usuário {model.UserName}Criado com Sucesso!!");
            }
            else
            {
                ModelState.AddModelError("CreateUser", "Registro Inválido");
                return BadRequest(ModelState);
            }
        }
    }
}
