using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticateService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<bool> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(string username, string email, string password)
        {
            var appUser = new IdentityUser
            {
                UserName = username,
                Email = email,
            };

            var result = await _userManager.CreateAsync(appUser, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, isPersistent: false);
            }

            return result.Succeeded;
        }
    }
}
