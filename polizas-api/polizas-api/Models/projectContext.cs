using Microsoft.EntityFrameworkCore;

namespace polizas_api.Models
{
    public class projectContext: DbContext
    {
        public projectContext(DbContextOptions<projectContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Client> Client { get; set; } = null!;
        public DbSet<Policy> Policy { get; set; } = null!;

        public string Conexion { get; }

        public projectContext(string valor)
        {
            Conexion = valor;
        }
    }
}
