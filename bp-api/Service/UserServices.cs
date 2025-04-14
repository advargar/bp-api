using bp_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bp_api.Service
{
    public class UserServices: IUserService
    {
        private readonly projectContext _context;
        public UserServices(projectContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(c => c.UserId == id);
        }
        public async Task<bool> UpdateAsync(int id, User user)
        {
            if (id != user.UserId)
                return false;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return false;

                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                return false;

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
