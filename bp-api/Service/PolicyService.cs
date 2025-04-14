using bp_api.Models;
using Microsoft.EntityFrameworkCore;
using static bp_api.Models.projectContext;

namespace bp_api.Service
{
    public class PolicyService: IPolicyService
    {
        private readonly projectContext _context;
        public PolicyService(projectContext context)
        {
            _context = context;
        }
        public async Task<List<Policy>> GetAllAsync()
        {
            return await _context.Policy.ToListAsync();
        }

        public async Task<Policy?> GetByIdAsync(string id)
        {
            return await _context.Policy.FirstOrDefaultAsync(c => c.PolicyNumber == id);
        }

        public async Task<bool> CreateAsync(Policy policy)
        {
            _context.Policy.Add(policy);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(string id, Policy policy)
        {
            if (id != policy.PolicyNumber)
                return false;

            _context.Entry(policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
                    return false;

                throw;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var policy = await _context.Policy.FindAsync(id);
            if (policy == null)
                return false;

            _context.Policy.Remove(policy);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool PolicyExists(string id)
        {
            return _context.Policy.Any(e => e.PolicyNumber == id);
        }

        public async Task<List<PolicyClientResult>> SearchPoliciesWithClientAsync(string? policyNumber,
            string? policyType, DateTime? expirationDate, string? insureId, 
            string? name, string? firstSurname, string? secondSurname)
        {
            var results = await _context.PolicyClientResults
                .FromSqlInterpolated($@"
            EXEC sp_SearchPoliciesWithClient 
                @PolicyNumber = {policyNumber}, 
                @PolicyType = {policyType}, 
                @ExpirationDate = {expirationDate}, 
                @InsureId = {insureId}, 
                @Name = {name}, 
                @FirstSurname = {firstSurname}, 
                @SecondSurname = {secondSurname}")
                .ToListAsync();

            return results;
        }

    }
}

