using Biblioteca.bd;
using Biblioteca.Constantes;
using Capa_Entidad;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca
{
    public class SBiblioteca : IBiblioteca
    {
        private readonly DBContext dBContext;
        public SBiblioteca(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public void AddDB(Bibli biblioteca)
        {
            dBContext.Bibliotecas.Add(biblioteca);
            dBContext.SaveChanges();
        }
        
        public Bibli CretateNew(int libro, int userId)
        {
            var biblioteca = new Bibli
            {
                LibroId = libro,
                UsuarioId = userId,
                Estado = ESTADO.POR_LEER
            };

            return biblioteca;
        }

        public List<Bibli> GetList(int userId)
        {
            var model = dBContext.Bibliotecas
              .Include(o => o.Libro.Autor)
              .Include(o => o.Usuario)
              .Where(o => o.UsuarioId == userId)
              .ToList();

            return model;
        }

        public void MarcarComoLeyendo(int libroId, int userId)
        {
            var libro = dBContext.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == userId)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            dBContext.SaveChanges();
        }

        public void MarcarComoTerminado(int libroId, int userId)
        {
            var libro = dBContext.Bibliotecas
              .Where(o => o.LibroId == libroId && o.UsuarioId == userId)
              .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            dBContext.SaveChanges();
        }
    }
}
