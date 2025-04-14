namespace polizas_api.Models
{
    public class Policy
    {
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
}
