using polizas_api.Models;

namespace polizas_api.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string username, string password);
        Task<User> SaveUser(User user);

    }
}
