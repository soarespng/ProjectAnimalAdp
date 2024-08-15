using Microsoft.EntityFrameworkCore;
using AnimalAdpApplication.Entities; // Certifique-se de importar o namespace correto

namespace AnimalAdpApplication.Data
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options)
            : base(options)
        {
            try
            {
                this.Database.OpenConnection();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }

        public DbSet<Animal> Animal { get; set; }

        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais se necessário
        }
    }
}
