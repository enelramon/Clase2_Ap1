using System.ComponentModel.DataAnnotations;

namespace Clase2.Entidades
{
    public class Libros
    {
        [Key]
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public string Grupo { get; set; }
        public string Autor { get; set; }
    }
}
