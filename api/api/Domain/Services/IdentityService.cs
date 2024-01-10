using api.Config;
using api.Domain.Dto.Request;
using api.Domain.Dto.Response;
using api.Domain.Interfaces;
using api.Domain.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api.Domain.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserRegisterResponse> Register(UserRegisterRequest userRequest)
        {
            var response = new UserRegisterResponse(false);

            var user = new User()
            {
                Fullname = userRequest.Fullname,
                UserName = userRequest.Email,
                Email = userRequest.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRequest.Password);
            if (result.Succeeded)
            {
                response.AddErrors(result.Errors.Select(r => r.Description));
                return response;
            }
            await _userManager.SetLockoutEnabledAsync(user, false);
            response = new UserRegisterResponse(true);
            return response;
        }

        public async Task<UserLoginResponse> UserLogin(UserLoginRequest userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);
            if (result.Succeeded)
            {
                return await GenerateToken(userLogin.Email);

            }

            var response = new UserLoginResponse(result.Succeeded);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    response.AddError("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    response.AddError("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    response.AddError("É necessário confirmar o login no seu segundo fator de autenticação.");
                else
                    response.AddError("Usuário ou senha estão incorretos");
            }
            return response;
        }

        private async Task<UserLoginResponse> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var tokenClaims = await GetClaims(user);
            var expirationDate = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken
            (
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: expirationDate,
                signingCredentials: _jwtOptions.SigningCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);


            return new UserLoginResponse
                (
                    success: true,
                    token: token,
                    expirationDate: expirationDate
                );

        }

        private async Task<IList<Claim>> GetClaims(User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }


            return claims;
        }
    }
}
