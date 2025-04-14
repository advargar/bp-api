using polizas_api.Models;
using Microsoft.EntityFrameworkCore;

namespace polizas_api.Services
{
    public class UserServices: IUserService
    {
        private readonly projectContext _context;
        public UserServices(projectContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(string username, string password)
        {
            
            User user = await _context.User.Where(m => m.UserName == username && m.Password == password)
                .FirstOrDefaultAsync();

            return user;
        }
        public async Task<User> SaveUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
