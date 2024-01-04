namespace api.Services
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUser(string username, string email, string password);
        Task Logout();
    }
}
