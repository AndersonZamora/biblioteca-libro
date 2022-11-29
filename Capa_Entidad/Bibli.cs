namespace Capa_Entidad
{
    public class Bibli
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public int Estado { get; set; }
        public Usuario Usuario { get; set; }
        public Libro Libro { get; set; }
    }
}
