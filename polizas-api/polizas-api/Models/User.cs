﻿namespace polizas_api.Models
{
    public class User
    {
        public required int UserId { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public required string Email { get; set; }
    }
}
