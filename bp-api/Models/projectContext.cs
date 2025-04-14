using Microsoft.EntityFrameworkCore;

namespace bp_api.Models
{
    public class projectContext: DbContext
    {
        public projectContext(DbContextOptions<projectContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Client> Client { get; set; } = null!;
        public DbSet<Policy> Policy { get; set; } = null!;
        public DbSet<PolicyClientResult> PolicyClientResults { get; set; }

        public string Conexion { get; }

        public projectContext(string valor)
        {
            Conexion = valor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyClientResult>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
