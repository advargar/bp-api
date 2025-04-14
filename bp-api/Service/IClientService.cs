using bp_api.Models;

namespace bp_api.Service
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(string id);
        Task<bool> CreateAsync(Client client);
        Task<bool> UpdateAsync(string id, Client client);
        Task<bool> DeleteAsync(string id);
        bool ClientExists(string id);
    }
}
