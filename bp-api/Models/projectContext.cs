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

            modelBuilder.Entity<Client>().HasData(
                  new Client
                  {
                      InsureId = "001230456",
                      Name = "Juan",
                      FirstSurname = "Pérez",
                      SecondSurname = "Gómez",
                      PersonType = "Física",
                      Birthdate = new DateTime(1985, 5, 12)
                  },
                  new Client
                  {
                      InsureId = "001230789",
                      Name = "Laura",
                      FirstSurname = "Ramírez",
                      SecondSurname = "Soto",
                      PersonType = "Física",
                      Birthdate = new DateTime(1990, 3, 22)
                  }
              );

            // Pólizas de prueba
            modelBuilder.Entity<Policy>().HasData(
                new Policy
                {
                    PolicyNumber = "POL12345",
                    PolicyType = "Alto",
                    Coverage = "Full",
                    PolicyStatus = "Activo",
                    CoverageAmount = 50000,
                    Premium = 250,
                    IssueDate = DateTime.Now.AddMonths(-6),
                    ExpirationDate = DateTime.Now.AddMonths(6),
                    InclusionDate = DateTime.Now.AddMonths(-6),
                    PolicyPeriod = DateTime.Now.AddMonths(8),
                    InsuranceCompany = "INS Costa Rica",
                    ClientId = "001230456"
                },
                new Policy
                {
                    PolicyNumber = "POL67890",
                    PolicyType = "Medio",
                    Coverage = "Regular",
                    PolicyStatus = "Proceso",
                    CoverageAmount = 30000,
                    Premium = 180,
                    IssueDate = DateTime.Now.AddMonths(-3),
                    ExpirationDate = DateTime.Now.AddMonths(9),
                    InclusionDate = DateTime.Now.AddMonths(-3),
                    PolicyPeriod = DateTime.Now.AddMonths(6),
                    InsuranceCompany = "INS Costa Rica",
                    ClientId = "001230789"
                }
            );

            // Usuarios de prueba
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 5,
                    UserName = "Admin",
                    Password = "admin123",
                    Role = "ADMINISTRADOR",
                    Email = "admin@gmail.com"
                },
                new User
                {
                    UserId = 6,
                    UserName = "Prueba",
                    Password = "prueba123",
                    Role = "LECTOR",
                    Email = "prueba@gmail.com"
                }
            );
        }



    }
}
