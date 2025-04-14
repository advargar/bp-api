using System.ComponentModel.DataAnnotations;

namespace bp_api.Models
{
    public class User
    {
        [Key]
        public required int UserId { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public required string Email { get; set; }
    }
}
