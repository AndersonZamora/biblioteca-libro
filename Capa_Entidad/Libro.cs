namespace Capa_Entidad
{
    public class Libro
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Imagen { get; set; }
        public int AutorId { get; set; }
        public double Puntaje { get; set; }
        public Author Autor { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
