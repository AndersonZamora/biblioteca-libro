using Capa_Entidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.bd
{
    public class BibliotecaMap : IEntityTypeConfiguration<Bibli>
    {
        public void Configure(EntityTypeBuilder<Bibli> builder)
        {
            builder.ToTable("Biblioteca");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Libro)
                .WithMany()
                .HasForeignKey(o => o.LibroId);
        }
    }
}
