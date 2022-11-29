using Capa_Entidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.bd
{
    public class LibroMap : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libro");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Autor)
                .WithMany()
                .HasForeignKey(o => o.AutorId);

            builder.HasMany(o => o.Comentarios)
                .WithOne()
                .HasForeignKey(o => o.LibroId);
        }
    }
}
