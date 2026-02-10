using System.ComponentModel.DataAnnotations;

namespace RegistroAlumnos.Models
{
    
    public class Alumno
    {
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Rut { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; }

        public bool Activo { get; set; } = true;
    }
}
