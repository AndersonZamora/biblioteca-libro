using Biblioteca.bd;
using Capa_Entidad;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
    public class SLibro : ILibro
    {
        private readonly DBContext dBContext;
        public SLibro(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public int AddComentario(Comentario comentario, int userId)
        {
            comentario.UsuarioId = userId;
            comentario.Fecha = DateTime.Now;
            dBContext.Comentarios.Add(comentario);

            var libro = dBContext.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            dBContext.SaveChanges();

            return comentario.LibroId;
        }

        public Libro Details(int libroId)
        {
            var model = dBContext.Libros
                 .Include("Autor")
                 .Include("Comentarios.Usuario")
                 .Where(o => o.Id == libroId)
                 .FirstOrDefault();

            return model;
        }

        public List<Libro> GetLibros()
        {
            return dBContext.Libros.Include(o => o.Autor).ToList();
        }
    }
}
