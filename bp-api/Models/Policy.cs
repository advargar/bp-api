using System.ComponentModel.DataAnnotations;

namespace bp_api.Models
{
    public class Policy
    {
        [Key]
        public required string PolicyNumber { get; set; }


        public required string PolicyType { get; set; }
        public decimal CoverageAmount { get; set; }
        public required DateTime ExpirationDate { get; set; }
        public required DateTime IssueDate { get; set; }
        public required string Coverage { get; set; }
        public required string PolicyStatus { get; set; }
        public required decimal Premium { get; set; }
        public required DateTime InclusionDate { get; set; }
        public required string InsuranceCompany { get; set; }

        public required string ClientId { get; set; }
        public required Client Client { get; set; } = null!;    
    }

    public class PolicyClientResult
    {
        public string PolicyNumber { get; set; }
        public string PolicyType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string InsureId { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
    }
}
