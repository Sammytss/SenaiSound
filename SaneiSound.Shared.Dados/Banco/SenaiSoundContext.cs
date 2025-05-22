using Microsoft.EntityFrameworkCore;
using SenaiSound.Modelos;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;
namespace SenaiSound.Banco
{
    public class SenaiSoundContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Genero> Generos{ get; set; }

        private static string servidor = "localhost";
        private static string banco = "senaisound_db";
        private static string usuario = "root";
        private static string senha = "123";

        private string conexaoDb = $"Server={servidor};Database={banco};User Id={usuario};Password={senha};Connection Timeout=60;";

        public SenaiSoundContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(conexaoDb, ServerVersion.AutoDetect(conexaoDb))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musica>()
                .HasMany(m => m.Generos)
                .WithMany(g => g.Musicas);
        }*/

    }
}
