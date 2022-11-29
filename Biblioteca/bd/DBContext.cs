using Capa_Entidad;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.bd
{
    public class DBContext : DbContext
    {
        public DBContext()
        {

        }

        public DBContext(DbContextOptions<DBContext> options) 
            : base(options){ }
     

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Bibli> Bibliotecas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Author> Autores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var ConnectionStrings = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(ConnectionStrings);
        }
    }
}
