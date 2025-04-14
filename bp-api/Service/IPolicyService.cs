using bp_api.Models;
using static bp_api.Models.projectContext;

namespace bp_api.Service
{
    public interface IPolicyService
    {

        Task<List<Policy>> GetAllAsync();
        Task<Policy?> GetByIdAsync(string id);
        Task<bool> CreateAsync(Policy policy);
        Task<bool> UpdateAsync(string id, Policy policy);
        Task<bool> DeleteAsync(string id);
        bool PolicyExists(string id);

        Task<List<PolicyClientResult>> SearchPoliciesWithClientAsync(string? policyNumber, 
            string? policyType, DateTime? expirationDate, string? insureId,
            string? name, string? firstSurname, string? secondSurname);

    }
}
