using api.Dto.Request;
using api.Dto.Response;

namespace api.Services.Interfaces
{
    public interface IIdentityService
    {
        public Task<UserRegisterResponse> Register(UserRegisterRequest userRequest);
        public Task<UserLoginResponse> UserLogin(UserLoginRequest userLogin);
    }
}
