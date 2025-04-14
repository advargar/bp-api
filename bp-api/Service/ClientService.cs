using bp_api.Models;
using bp_api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bp_api.NewFolder
{
    public class ClientService : IClientService
    {
        private readonly projectContext _context;
        public ClientService(projectContext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(string id)
        {
            return await _context.Client.FirstOrDefaultAsync(c => c.InsureId == id);
        }

        public async Task<bool> CreateAsync(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(string id, Client client)
        {
            if (id != client.InsureId)
                return false;

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                    return false;

                throw;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client == null)
                return false;

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ClientExists(string id)
        {
            return _context.Client.Any(e => e.InsureId == id);
        }
    }
}
