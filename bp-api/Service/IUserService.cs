using bp_api.Models;

namespace bp_api.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
        bool UserExists(int id);
    }
}
