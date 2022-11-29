using Capa_Entidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.bd
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Usuario)
                .WithMany()
                .HasForeignKey(o => o.UsuarioId);
        }
    }
}
