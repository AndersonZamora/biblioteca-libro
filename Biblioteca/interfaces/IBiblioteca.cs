using Capa_Entidad;

namespace Biblioteca
{
    public interface IBiblioteca
    {
        List<Bibli> GetList(int userId);
        Bibli CretateNew(int libro, int userId);
        void AddDB(Bibli biblioteca);
        void MarcarComoLeyendo(int libroId, int userId);
        void MarcarComoTerminado(int libroId, int userId);
    }
}
