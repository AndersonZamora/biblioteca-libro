using Capa_Entidad;

namespace Biblioteca
{
    public interface ILibro
    {
        int AddComentario(Comentario comentario, int userId);
        Libro Details(int libroId);
        List<Libro> GetLibros();
    }
}
