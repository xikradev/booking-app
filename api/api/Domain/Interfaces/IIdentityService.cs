using api.Domain.Dto.Request;
using api.Domain.Dto.Response;

namespace api.Domain.Interfaces
{
    public interface IIdentityService
    {
        public Task<UserRegisterResponse> Register(UserRegisterRequest userRequest);
        public Task<UserLoginResponse> UserLogin(UserLoginRequest userLogin);
    }
}
