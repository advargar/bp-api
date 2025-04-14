using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bp_api.Models;
using bp_api.Service;

namespace bp_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            var policies = await _policyService.GetAllAsync();
            return Ok(policies);
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(string id)
        {
            var policy = await _policyService.GetByIdAsync(id);

            if (policy == null)
                return NotFound();

            return Ok(policy);
        }

        // POST: api/Policies
        [HttpPost]
        public async Task<ActionResult<Policy>> CreatePolicy(Policy policy)
        {
            var created = await _policyService.CreateAsync(policy);

            if (!created)
                return BadRequest();

            return CreatedAtAction(nameof(GetPolicy), new { id = policy.PolicyNumber }, policy);
        }

        // PUT: api/Policies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(string id, Policy policy)
        {
            var updated = await _policyService.UpdateAsync(id, policy);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(string id)
        {
            var deleted = await _policyService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPoliciesWithClient(
            [FromQuery] string? policyNumber,
            [FromQuery] string? policyType,
            [FromQuery] DateTime? expirationDate,
            [FromQuery] string? insureId,
            [FromQuery] string? name,
            [FromQuery] string? firstSurname,
            [FromQuery] string? secondSurname)
        {
            var result = await _policyService.SearchPoliciesWithClientAsync(
                policyNumber, policyType, expirationDate, insureId, name, firstSurname, secondSurname);

            return Ok(result);
        }

    }
}
