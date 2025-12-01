using System.ComponentModel.DataAnnotations;

namespace ZooModelos2.Models
{
    public class Especie
    {
        [Key] public int Codigo { get; set; }
        public string NombreComun { get; set; } = string.Empty;

        // Navegacion
        public List<Animal>? Animales { get; set; }
    }
}
