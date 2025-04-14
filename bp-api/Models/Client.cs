using System.ComponentModel.DataAnnotations;

namespace bp_api.Models
{
    public class Client
    {
        [Key]
        public required string InsureId { get; set; }


        public required string Name { get; set; }
        public required string FirstSurname { get; set; }
        public required string SecondSurname { get; set; }
        public required string PersonType { get; set; }
        public required DateTime Birtdate { get; set; }

        public ICollection<Policy> Policies { get; set; } = new List<Policy>();

    }
}
