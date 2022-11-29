namespace Capa_Entidad
{
    public class Comentario
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int UsuarioId { get; set; }
        public String Texto { get; set; }
        public DateTime Fecha { get; set; }
        public int Puntaje { get; set; }
        public Usuario Usuario { get; set; }
    }
}
